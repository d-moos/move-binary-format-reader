namespace MoveBinaryReader.Models;

public struct StructDefinition : IReadableMoveModel
{
    public ulong StructHandle { get; set; }
    public FieldInformation FieldInformation { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModel<ULEB128>(out var structHandle))
            return false;

        if (!reader.TryReadModel<FieldInformation>(out var fieldInformation))
            return false;

        StructHandle = structHandle;
        FieldInformation = fieldInformation;

        return true;
    }
}