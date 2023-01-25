using Explorer.ObjectTypes;

namespace Explorer.Mapper;

public static class StructDefInstantiationMapper
{
    public static StructDefInstantiation ToObjectType(
        this MoveBinaryReader.Models.StructDefInstantiation structDefInstantiation,
     string moduleIdentifier)
        => new(
            Convert.ToInt64(structDefInstantiation.StructHandle),
            Convert.ToInt64(structDefInstantiation.Instantiation),
            moduleIdentifier
        );
}