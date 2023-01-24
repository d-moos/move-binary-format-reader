using Explorer.DataLoader;
using Explorer.Mapper;

namespace Explorer.ObjectTypes;

public record FunctionInstantiation(
    long FunctionHandleIndex,
    long InstantiationIndex
)
{
    public async Task<FunctionHandle> FunctionHandle(FunctionHandleDataLoader dataLoader)
    {
        var functionHandle = await dataLoader.LoadAsync(Convert.ToUInt64(FunctionHandleIndex));
        return functionHandle.ToObjectType();
    }

    public async Task<Signature.Signature> Instantiation(SignatureDataLoader dataLoader)
    {
        var signature = await dataLoader.LoadAsync(Convert.ToUInt64(InstantiationIndex));
        return signature.ToObjectType();
    }
}