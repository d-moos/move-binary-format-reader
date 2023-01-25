using Explorer.DataLoader;
using Explorer.Mapper;
using Explorer.ObjectTypes.StructDefinition;

namespace Explorer.ObjectTypes;

public record FunctionInstantiation(
    long FunctionHandleIndex,
    long InstantiationIndex
    , string ModuleIdentifier) : ModuleContent(ModuleIdentifier)
{
    public async Task<FunctionHandle> FunctionHandle(FunctionHandleDataLoader dataLoader)
    {
        var functionHandle = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(FunctionHandleIndex)));
        return functionHandle.ToObjectType(ModuleIdentifier);
    }

    public async Task<Signature.Signature> Instantiation(SignatureDataLoader dataLoader)
    {
        var signature = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(InstantiationIndex)));
        return signature.ToObjectType();
    }
}