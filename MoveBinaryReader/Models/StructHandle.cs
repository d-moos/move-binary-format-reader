namespace MoveBinaryReader.Models;

public struct StructHandle : IReadableMoveModel
{
    /// <summary>
    /// ULEB128 index in the MODULE_HANDLES table of the module where the struct is defined
    /// </summary>
    public ulong Module { get; set; }

    /// <summary>
    /// ULEB128 index into the IDENTIFIERS table of the name of the struct
    /// </summary>
    public ulong Name { get; set; }

    /// <summary>
    /// U8 bool defining whether the struct is a resource (true/1) or not (false/0)
    /// </summary>
    public Ability NominalResource { get; set; }

    /// <summary>
    /// vector of type parameter kinds if the struct is generic, an empty vector otherwise:
    /// - length: ULEB128 length of the vector, effectively the number of type parameters for the generic struct
    /// - kinds: array of length U8 kind values; not present if length is 0
    /// </summary>
    public StructTypeParameter[] TypeParameters { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModel<ULEB128>(out var module))
            return false;

        if (!reader.TryReadModel<ULEB128>(out var name))
            return false;

        if (!reader.TryRead<Ability>(out var nominalResource))
            return false;

        if (!reader.TryReadVector<StructTypeParameter>(out var typeParameters))
            return false;

        Module = module;
        Name = name;
        NominalResource = nominalResource;
        TypeParameters = typeParameters;

        return true;
    }
}