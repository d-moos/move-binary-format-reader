using MoveBinaryReader;
using MoveBinaryReader.Models;

namespace MoveBinaryReaderTests;

public abstract class BaseSmokeTest : IDisposable
{
    private readonly FileStream _fileStream;
    protected IMoveReader MoveReader;

    private readonly FileHeader _fileHeader;
    private readonly Dictionary<TableKind, TableHeader> _tableHeaders;
    private readonly ushort _endOfHeaderPosition;

    public BaseSmokeTest()
    {
        _fileStream = File.OpenRead("btc.mv");
        var bytes = new byte[_fileStream.Length];
        _fileStream.Read(bytes, 0, bytes.Length);

        MoveReader = new MoveReader(bytes);
        if (!MoveReader.TryReadModel<FileHeader>(out var fileHeader))
            throw new Exception($"could not read {nameof(FileHeader)}");
        _fileHeader = fileHeader;

        if (!MoveReader.TryReadModelCollection<TableHeader>(out var tableHeaders, _fileHeader.TableCount))
            throw new Exception($"could not read {nameof(TableHeader)}");
        _tableHeaders = tableHeaders.ToDictionary(x => x.Kind);

        _endOfHeaderPosition = MoveReader.ReadPosition;
    }

    protected (ushort Start, ushort End) GetTableRange(TableKind kind)
    {
        var header = _tableHeaders[kind];
        var startingPosition = (ushort)(_endOfHeaderPosition + header.Offset);
        var endPosition = (ushort)(startingPosition + header.Length);

        return (startingPosition, endPosition);
    }

    public void Dispose()
    {
        _fileStream.Dispose();
    }
}