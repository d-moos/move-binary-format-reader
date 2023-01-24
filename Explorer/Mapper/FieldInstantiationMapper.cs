using MoveBinaryReader.Models;

namespace Explorer.Mapper;

public static class FieldInstantiationMapper
{
    public static ObjectTypes.FieldInstantiation ToObjectType(this FieldInstantiation fieldInstantiation) =>
        new(
            Convert.ToInt64(fieldInstantiation.FieldHandle),
            Convert.ToInt64(fieldInstantiation.Instantiation)
        );
}