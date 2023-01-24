using Explorer.DataLoader;
using Explorer.Mapper;

namespace Explorer.ObjectTypes.StructDefinition;

public record StructDefinition(long StructHandleIndex, FieldInformation FieldInformation)
{
    public async Task<StructHandle> StructHandle(StructHandleDataLoader dataLoader)
    {
        var structHandle = await dataLoader.LoadAsync(Convert.ToUInt64(StructHandleIndex));
        return structHandle.ToObjectType();
    }
}