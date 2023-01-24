using MoveBinaryReader;
using MoveBinaryReader.Models;
using ModuleHandle = MoveBinaryReader.Models.ModuleHandle;

namespace Explorer;

public class MoveFile : IMoveFile, IDisposable
{
    private readonly string _path;
    private readonly FileStream _fileStream;
    private readonly IMoveReader _reader;

    
    private readonly FileHeader _fileHeader;
    private readonly Dictionary<TableKind, TableHeader> _tableHeaders;
    private readonly ushort _endOfHeaderPosition;
    
    public MoveFile(string path)
    {
        _path = path;
        
        _fileStream = File.OpenRead("btc.mv");
        var bytes = new byte[_fileStream.Length];
        _fileStream.Read(bytes, 0, bytes.Length);

        _reader = new MoveReader(bytes);
        if (!_reader.TryReadModel<FileHeader>(out var fileHeader))
            throw new Exception($"could not read {nameof(FileHeader)}");
        _fileHeader = fileHeader;

        if (!_reader.TryReadModelCollection<TableHeader>(out var tableHeaders, _fileHeader.TableCount))
            throw new Exception($"could not read {nameof(TableHeader)}");
        _tableHeaders = tableHeaders.ToDictionary(x => x.Kind);

        _endOfHeaderPosition = _reader.ReadPosition;
    }

    public FileHeader FileHeader => _fileHeader;
    public TableHeader TableHeader(TableKind kind) => _tableHeaders[kind];

    public IReadOnlyCollection<T>? ReadTable<T>(TableKind kind) where T : IReadableMoveModel, new()
    {
        var range = GetTableRange(kind);
        var result = _reader.TryReadModelCollectionInRange(out T[] collection, range.Start, range.End);

        return !result ? null : collection;
    }

    private (ushort Start, ushort End) GetTableRange(TableKind kind)
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
