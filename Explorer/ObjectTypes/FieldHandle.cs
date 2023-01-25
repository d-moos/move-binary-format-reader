using Explorer.DataLoader;
using Explorer.Mapper;
using Explorer.ObjectTypes.StructDefinition;

namespace Explorer.ObjectTypes;

public record FieldHandle(long OwnerIndex, long Position, string ModuleIdentifier) : ModuleContent(ModuleIdentifier)
{
    public async Task<StructDefinition.StructDefinition> Owner(StructDefinitionDataLoader dataLoader)
    {
        var structDefinition = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(OwnerIndex)));
        return structDefinition.ToObjectType(ModuleIdentifier);
    }
}