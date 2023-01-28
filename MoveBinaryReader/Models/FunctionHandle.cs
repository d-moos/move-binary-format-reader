namespace MoveBinaryReader.Models;

public struct FunctionHandle : IReadableMoveModel
{
    public ulong Module { get; set; }
    public ulong Name { get; set; }
    public ulong Parameters { get; set; }
    public ulong Return { get; set; }
    public Ability[] Abilities { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModel<ULEB128>(out var module))
            return false;

        if (!reader.TryReadModel<ULEB128>(out var name))
            return false;

        if (!reader.TryReadModel<ULEB128>(out var parameters))
            return false;

        if (!reader.TryReadModel<ULEB128>(out var returnValue))
            return false;

        if (!reader.TryReadVector<Ability>(out var abilityFlags))
            return false;

        Module = module;
        Name = name;
        Parameters = parameters;
        Return = returnValue;
        Abilities = abilityFlags.Length == 0 ? Array.Empty<Ability>() : abilityFlags; 

        return true;
    }
}