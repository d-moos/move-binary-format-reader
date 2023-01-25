using Explorer.DataLoader;
using Explorer.Mapper;
using Explorer.ObjectTypes.Signature;

namespace Explorer.ObjectTypes.StructDefinition;

public record Field(long NameIndex, Token FieldType, string ModuleIdentifier) : ModuleContent(ModuleIdentifier)
{
    public async Task<Identifier> Name(IdentifierDataLoader dataLoader)
    {
        var identifier = await dataLoader.LoadAsync((ModuleIdentifier, Convert.ToUInt64(NameIndex)));
        return identifier.ToObjectType();
    }
}