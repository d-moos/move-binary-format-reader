namespace MoveBinaryReader.Models;

public struct FieldHandle : IReadableMoveModel
{
    public ulong Owner { get; set; }
    public ulong Index { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModel<ULEB128>(out var owner))
            return false;
        
        if (!reader.TryReadModel<ULEB128>(out var index))
            return false;

        Owner = owner;
        Index = index;

        return true;
    }
}