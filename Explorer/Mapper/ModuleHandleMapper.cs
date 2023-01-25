using ModuleHandle = Explorer.ObjectTypes.ModuleHandle;

namespace Explorer.Mapper;

public static class ModuleHandleMapper
{
    public static ModuleHandle ToObjectType(this MoveBinaryReader.Models.ModuleHandle moduleHandle, string moduleIdentifier) =>
        new(Convert.ToInt64(moduleHandle.Address), Convert.ToInt64(moduleHandle.Name), moduleIdentifier);
}