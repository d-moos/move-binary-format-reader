using Explorer.DataLoader;
using Explorer.Mapper;
using Explorer.ObjectTypes.StructDefinition;

namespace Explorer.ObjectTypes;

public record StructHandle(
    long ModuleIndex,
    long NameIndex,
    Ability[] Abilities,
    StructTypeParameter[] StructTypeParameters
    , string ModuleIdentifier) : ModuleContent(ModuleIdentifier)
{
    public async Task<ModuleHandle> ModuleHandle(ModuleHandleDataLoader dataLoader)
    {
        var moduleHandle = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(ModuleIndex)));
        return moduleHandle.ToObjectType(ModuleIdentifier);
    }

    public async Task<Identifier> Name(IdentifierDataLoader dataLoader)
    {
        var identifier = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(NameIndex)));
        return identifier.ToObjectType();
    }
}