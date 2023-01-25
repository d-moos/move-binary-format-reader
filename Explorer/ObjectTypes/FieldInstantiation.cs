using Explorer.DataLoader;
using Explorer.Mapper;
using Explorer.ObjectTypes.StructDefinition;

namespace Explorer.ObjectTypes;

public record FieldInstantiation(long FieldHandleIndex, long InstantiationIndex, string ModuleIdentifier) : ModuleContent(ModuleIdentifier)
{
    public async Task<FieldHandle> FieldHandle(FieldHandleDataLoader dataLoader)
    {
        var fieldHandle = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(FieldHandleIndex)));
        return fieldHandle.ToObjectType(ModuleIdentifier);
    }

    public async Task<Signature.Signature> Instantiation(SignatureDataLoader dataLoader)
    {
        var instantiation = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(InstantiationIndex)));
        return instantiation.ToObjectType();
    }
}