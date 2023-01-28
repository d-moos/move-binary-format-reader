namespace MoveBinaryReader.Models;

public struct StructDefInstantiation : IReadableMoveModel
{
    public ulong StructHandle { get; set; }
    public ulong Instantiation { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModel<ULEB128>(out var structHandle))
            return false;
        
        if (!reader.TryReadModel<ULEB128>(out var instantiation))
            return false;

        StructHandle = structHandle;
        Instantiation = instantiation;
        
        return true;
    }
}