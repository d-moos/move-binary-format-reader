using Explorer.DataLoader;
using Explorer.Mapper;

namespace Explorer.ObjectTypes;

public record FunctionHandle(
    long ModuleIndex,
    long NameIndex,
    long ParametersIndex,
    long ReturnIndex,
    Ability[] Abilities
)
{
    public async Task<ModuleHandle> ModuleHandle(ModuleHandleDataLoader dataLoader)
    {
        var moduleHandle = await dataLoader.LoadAsync(Convert.ToUInt64(ModuleIndex));
        return moduleHandle.ToObjectType();
    }

    public async Task<Identifier> Name(IdentifierDataLoader dataLoader)
    {
        var name = await dataLoader.LoadAsync(Convert.ToUInt64(NameIndex));
        return name.ToObjectType();
    }

    public async Task<Signature.Signature> Parameters(SignatureDataLoader dataLoader)
    {
        var signature = await dataLoader.LoadAsync(Convert.ToUInt64(ParametersIndex));
        return signature.ToObjectType();
    }

    public async Task<Signature.Signature> ReturnType(SignatureDataLoader dataLoader)
    {
        var signature = await dataLoader.LoadAsync(Convert.ToUInt64(ReturnIndex));
        return signature.ToObjectType();
    }
}