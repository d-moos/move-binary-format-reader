namespace MoveBinaryReader.Models;

public struct FieldHandles : IReadableMoveModel
{
    public ulong Owner { get; set; }
    public ulong Index { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadULEB128(out var owner))
            return false;
        
        if (!reader.TryReadULEB128(out var index))
            return false;

        Owner = owner;
        Index = index;

        return true;
    }
}