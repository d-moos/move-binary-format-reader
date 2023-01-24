using Explorer.ObjectTypes;

namespace Explorer.Mapper;

public static class FunctionHandleMapper
{
    public static FunctionHandle ToObjectType(this MoveBinaryReader.Models.FunctionHandle functionHandle) =>
        new(
            Convert.ToInt64(functionHandle.Module),
            Convert.ToInt64(functionHandle.Name),
            Convert.ToInt64(functionHandle.Parameters),
            Convert.ToInt64(functionHandle.Return),
            functionHandle.Ability.ToObjectType()
        );
}