namespace MoveBinaryReader.Models;

public struct ModuleHandle : IReadableMoveModel
{
    /// <summary>
    /// ULEB128 index into the ADDRESS_IDENTIFIERS table of the account under which the module is published
    /// </summary>
    public ulong Address { get; set; }

    /// <summary>
    /// ULEB128 index into the IDENTIFIERS table of the name of the module
    /// </summary>
    public ulong Name { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadULEB128(out var address))
            return false;

        if (!reader.TryReadULEB128(out var name))
            return false;

        Address = address;
        Name = name;

        return true;
    }
}