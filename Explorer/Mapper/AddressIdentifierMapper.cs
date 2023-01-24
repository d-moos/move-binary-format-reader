using Explorer.ObjectTypes;

namespace Explorer.Mapper;

public static class AddressIdentifierMapper
{
    public static AddressIdentifier ToObjectType(this MoveBinaryReader.Models.AddressIdentifier addressIdentifier) =>
        new(Convert.ToHexString(addressIdentifier.Address));
}