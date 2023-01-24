namespace MoveBinaryReader.Models;

public struct FunctionHandle : IReadableMoveModel
{
    /// <summary>
    /// ULEB128 index in the MODULE_HANDLES table of the module where the function is defined
    /// </summary>
    public ulong Module { get; set; }

    /// <summary>
    /// ULEB128 index into the IDENTIFIERS table of the name of the function
    /// </summary>
    public ulong Name { get; set; }

    /// <summary>
    /// ULEB128 index into the SIGNATURES table for the argument types of the function
    /// </summary>
    public ulong Parameters { get; set; }

    /// <summary>
    /// ULEB128 index into the SIGNATURES table for the return types of the function
    /// </summary>
    public ulong Return { get; set; }

    /// <summary>
    /// vector of type parameter kinds if the function is generic, an empty vector otherwise:
    /// - length: ULEB128 length of the vector, effectively the number of type parameters for the generic function
    /// - kinds: array of length U8 kind values; not present if length is 0
    /// </summary>
    public Ability Ability { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadULEB128(out var module))
            return false;

        if (!reader.TryReadULEB128(out var name))
            return false;

        if (!reader.TryReadULEB128(out var parameters))
            return false;

        if (!reader.TryReadULEB128(out var returnValue))
            return false;

        if (!reader.TryReadUleb128Collection<Ability>(out var abilityFlags))
            return false;

        Module = module;
        Name = name;
        Parameters = parameters;
        Return = returnValue;
        Ability = abilityFlags.Length == 0 ? Ability.Empty : abilityFlags.First();  // TODO: @mystenlabs why a vector? 

        return true;
    }
}