using Explorer.DataLoader;
using Explorer.Mapper;

namespace Explorer.ObjectTypes;

public record ModuleHandle(long AddressIndex, long NameIndex)
{
    public async Task<AddressIdentifier> Package(AddressDataLoader dataLoader)
    {
        var identifier = await dataLoader.LoadAsync((ulong)AddressIndex);
        return identifier.ToObjectType();
    }

    public async Task<Identifier> Name(IdentifierDataLoader dataLoader)
    {
        var identifier = await dataLoader.LoadAsync((ulong)NameIndex);
        return identifier.ToObjectType();
    }
};