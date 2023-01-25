using Explorer.ObjectTypes;

namespace Explorer.Mapper;

public static class FunctionInstantiationMapper
{
    public static FunctionInstantiation ToObjectType(
        this MoveBinaryReader.Models.FunctionInstantiation functionInstantiation, string moduleIdentifier
    )
        => new(
            Convert.ToInt64(functionInstantiation.FunctionHandle),
            Convert.ToInt64(functionInstantiation.Instantiation),
            moduleIdentifier
        );
}