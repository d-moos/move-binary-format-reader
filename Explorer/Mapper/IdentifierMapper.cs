using Explorer.ObjectTypes;

namespace Explorer.Mapper;

public static class IdentifierMapper
{
    public static Identifier ToObjectType(this MoveBinaryReader.Models.Identifier identifier) => new(identifier.Value);
}