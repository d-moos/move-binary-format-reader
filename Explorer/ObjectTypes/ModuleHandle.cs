using Explorer.DataLoader;
using Explorer.Mapper;
using Explorer.ObjectTypes.StructDefinition;

namespace Explorer.ObjectTypes;

public record ModuleHandle(long AddressIndex, long NameIndex, string ModuleIdentifier) : ModuleContent(ModuleIdentifier)
{
    public async Task<AddressIdentifier> Package(AddressIdentifierDataLoader dataLoader)
    {
        var identifier = await dataLoader.LoadAsync((ModuleIdentifier, (ulong)AddressIndex));
        return identifier.ToObjectType();
    }

    public async Task<Identifier> Name(IdentifierDataLoader dataLoader)
    {
        var identifier = await dataLoader.LoadAsync((ModuleIdentifier, (ulong)NameIndex));
        return identifier.ToObjectType();
    }
};