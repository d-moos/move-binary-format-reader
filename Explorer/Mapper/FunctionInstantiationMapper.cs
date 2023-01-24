using Explorer.ObjectTypes;

namespace Explorer.Mapper;

public static class FunctionInstantiationMapper
{
    public static FunctionInstantiation ToObjectType(
        this MoveBinaryReader.Models.FunctionInstantiation functionInstantiation
    )
        => new(
            Convert.ToInt64(functionInstantiation.FunctionHandle),
            Convert.ToInt64(functionInstantiation.Instantiation)
        );
}

public static class StructDefInstantiationMapper
{
    public static StructDefInstantiation ToObjectType(
        this MoveBinaryReader.Models.StructDefInstantiation structDefInstantiation
    )
        => new(
            Convert.ToInt64(structDefInstantiation.StructHandle),
            Convert.ToInt64(structDefInstantiation.Instantiation)
        );
}