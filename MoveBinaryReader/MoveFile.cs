using MoveBinaryReader.Models;

namespace MoveBinaryReader;

public class MoveBinaryFile : IMoveFile
{
    private readonly IMoveReader _reader;
    private readonly FileHeader _fileHeader;
    private readonly Dictionary<TableKind, TableHeader> _tableHeaders;
    private readonly ushort _endOfHeaderPosition;

    public MoveBinaryFile(Memory<byte> data)
    {
        _reader = new MoveReader(data);
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

    public IReadOnlyCollection<T> ReadTable<T>(TableKind kind) where T : IReadableMoveModel, new()
    {
        var range = GetTableRange(kind);

        if (!range.HasValue)
            return Array.Empty<T>();
        
        var result = _reader.TryReadModelCollectionInRange(out T[] collection, range.Value.Start, range.Value.End);

        return !result ? Array.Empty<T>() : collection;
    }

    private (ushort Start, ushort End)? GetTableRange(TableKind kind)
    {
        if (!_tableHeaders.ContainsKey(kind))
            return null;
            
        var header = _tableHeaders[kind];
        var startingPosition = (ushort)(_endOfHeaderPosition + header.Offset);
        var endPosition = (ushort)(startingPosition + header.Length);

        return (startingPosition, endPosition);
    }

}