using Explorer.DataLoader;
using Explorer.Mapper;

namespace Explorer.ObjectTypes.StructDefinition;

public record StructDefinition(long StructHandleIndex, FieldInformation FieldInformation, string ModuleIdentifier) : ModuleContent(ModuleIdentifier)
{
    public async Task<StructHandle> StructHandle(StructHandleDataLoader dataLoader)
    {
        var structHandle = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(StructHandleIndex)));
        return structHandle.ToObjectType(ModuleIdentifier);
    }
}