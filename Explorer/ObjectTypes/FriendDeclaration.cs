using Explorer.DataLoader;
using Explorer.Mapper;
using Explorer.ObjectTypes.StructDefinition;

namespace Explorer.ObjectTypes;

public record FriendDeclaration(long AddressIndex, long NameIndex, string ModuleIdentifier) : ModuleContent(ModuleIdentifier)
{
    public async Task<AddressIdentifier> Address(AddressIdentifierDataLoader dataLoader)
    {
        var address = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(AddressIndex)));
        return address.ToObjectType();
    }

    public async Task<Identifier> Name(IdentifierDataLoader dataLoader)
    {
        var name = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(NameIndex)));
        return name.ToObjectType();
    }
}