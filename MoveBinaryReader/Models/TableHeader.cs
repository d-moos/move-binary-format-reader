namespace MoveBinaryReader.Models;

public struct TableHeader : IReadableMoveModel
{
    public TableKind Kind { get; set; }
    public ulong Offset { get; set; }
    public ulong Length { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryRead<TableKind>(out var kind))
            return false;
        if (!reader.TryReadModel<ULEB128>(out var offset))
            return false;
        if (!reader.TryReadModel<ULEB128>(out var length))
            return false;

        Kind = kind;
        Offset = offset;
        Length = length;

        return true;
    }
};