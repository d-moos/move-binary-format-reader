using Explorer.DataLoader;
using Explorer.Mapper;

namespace Explorer.ObjectTypes;

public record FieldHandle(long OwnerIndex, long Position)
{
    public async Task<StructDefinition.StructDefinition> Owner(StructDefinitionDataLoader dataLoader)
    {
        var structDefinition = await dataLoader.LoadAsync(Convert.ToUInt64(OwnerIndex));
        return structDefinition.ToObjectType();
    }
}

public record StructDefInstantiation(long StructHandleIndex, long InstantiationIndex)
{
    public async Task<StructHandle> StructHandle(StructHandleDataLoader dataLoader)
    {
        var structDefinition = await dataLoader.LoadAsync(Convert.ToUInt64(StructHandleIndex));
        return structDefinition.ToObjectType();
    }
    
    public async Task<Signature.Signature> Owner(SignatureDataLoader dataLoader)
    {
        var structDefinition = await dataLoader.LoadAsync(Convert.ToUInt64(InstantiationIndex));
        return structDefinition.ToObjectType();
    }
};