using Explorer.DataLoader;
using Explorer.Mapper;

namespace Explorer.ObjectTypes;

public record StructHandle(
    long ModuleIndex,
    long NameIndex,
    Ability[] Abilities,
    StructTypeParameter[] StructTypeParameters
)
{
    public async Task<ModuleHandle> ModuleHandle(ModuleHandleDataLoader dataLoader)
    {
        var moduleHandle = await dataLoader.LoadAsync(Convert.ToUInt64(ModuleIndex));
        return moduleHandle.ToObjectType();
    }

    public async Task<Identifier> Name(IdentifierDataLoader dataLoader)
    {
        var identifier = await dataLoader.LoadAsync(Convert.ToUInt64(NameIndex));
        return identifier.ToObjectType();
    }
}