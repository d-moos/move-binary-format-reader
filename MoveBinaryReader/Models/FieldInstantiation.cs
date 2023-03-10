namespace MoveBinaryReader.Models;

public struct FieldInstantiation : IReadableMoveModel
{
    public ulong FieldHandle { get; set; }
    public ulong Instantiation { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModel<ULEB128>(out var fieldHandle))
            return false;
        
        if (!reader.TryReadModel<ULEB128>(out var instantiation))
            return false;

        FieldHandle = fieldHandle;
        Instantiation = instantiation;

        return true;
    }
}