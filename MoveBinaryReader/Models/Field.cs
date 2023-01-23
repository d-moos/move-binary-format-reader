using MoveBinaryReader.Models.Signature;

namespace MoveBinaryReader.Models;

public struct Field : IReadableMoveModel
{
    public ulong Name { get; set; }
    public SignatureToken Type { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadULEB128(out var name))
            return false;

        if (!reader.TryReadModel<SignatureToken>(out var signature))
            return false;

        Name = name;
        Type = signature;

        return true;
    }
}