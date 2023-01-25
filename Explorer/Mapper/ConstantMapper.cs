using Explorer.ObjectTypes;

namespace Explorer.Mapper;

public static class ConstantMapper
{
    public static Constant ToObjectType(this MoveBinaryReader.Models.Constant constant) =>
        new(constant.SignatureToken.ToObjectType(), constant.SerializedValue);
}