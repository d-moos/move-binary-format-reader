using Explorer.DataLoader;
using Explorer.Mapper;

namespace Explorer.ObjectTypes;

public record FieldInstantiation(long FieldHandleIndex, long InstantiationIndex)
{
    public async Task<FieldHandle> FieldHandle(FieldHandleDataLoader dataLoader)
    {
        var fieldHandle = await dataLoader.LoadAsync(Convert.ToUInt64(FieldHandleIndex));
        return fieldHandle.ToObjectType();
    }

    public async Task<Signature.Signature> Instantiation(SignatureDataLoader dataLoader)
    {
        var instantiation = await dataLoader.LoadAsync(Convert.ToUInt64(InstantiationIndex));
        return instantiation.ToObjectType();
    }
}