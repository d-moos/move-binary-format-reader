using Explorer.ObjectTypes;
using MoveBinaryReader.Models;
using FieldHandle = Explorer.ObjectTypes.FieldHandle;

namespace Explorer.Mapper;

public static class FieldHandleMapper
{
    public static FieldHandle ToObjectType(this MoveBinaryReader.Models.FieldHandle fieldHandle, string moduleIdentifier) =>
        new(Convert.ToInt64(fieldHandle.Owner), Convert.ToInt64(fieldHandle.Index), moduleIdentifier);
}