namespace MoveBinaryReader.Models;

public struct FileHeader : IReadableMoveModel
{
    public byte[] Magic { get; set; }
    public uint Version { get; set; }
    public ulong TableCount { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        var magic = new byte[4];
        var span = new Span<byte>(magic);
        if (!reader.TryRead(span))
            return false;

        if (!reader.TryRead<uint>(out var version))
            return false;

        if (!reader.TryReadULEB128(out var tableCount))
            return false;

        Version = version;
        TableCount = tableCount;
        Magic = magic;
        
        return true;
    }
}