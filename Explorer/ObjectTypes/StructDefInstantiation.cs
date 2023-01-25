using Explorer.DataLoader;
using Explorer.Mapper;
using Explorer.ObjectTypes.StructDefinition;

namespace Explorer.ObjectTypes;

public record StructDefInstantiation(long StructHandleIndex, long InstantiationIndex, string ModuleIdentifier) : ModuleContent(ModuleIdentifier)
{
    public async Task<StructHandle> StructHandle(StructHandleDataLoader dataLoader)
    {
        var structDefinition = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(StructHandleIndex)));
        return structDefinition.ToObjectType(ModuleIdentifier);
    }
    
    public async Task<Signature.Signature> Owner(SignatureDataLoader dataLoader)
    {
        var structDefinition = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(InstantiationIndex)));
        return structDefinition.ToObjectType();
    }
};