using MoveBinaryReader.Models;

namespace Explorer.Mapper;

public static class FieldInstantiationMapper
{
    public static ObjectTypes.FieldInstantiation ToObjectType(this FieldInstantiation fieldInstantiation, string moduleIdentifier) =>
        new(
            Convert.ToInt64(fieldInstantiation.FieldHandle),
            Convert.ToInt64(fieldInstantiation.Instantiation),
            moduleIdentifier
        );
}