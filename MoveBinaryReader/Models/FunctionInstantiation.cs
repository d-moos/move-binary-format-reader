namespace MoveBinaryReader.Models;

/// <summary>
/// A Function Instantiation describes the instantation of a generic function.
/// Function Instantiation can be full or partial. E.g., given a generic function f<K, V>() a full instantiation would be f<U8, Bool>()
/// whereas a partial instantiation would be f<U8, Z>() where Z is a type parameter in a given context (typically another function g<Z>()).
/// </summary>
public struct FunctionInstantiation : IReadableMoveModel
{
    /// <summary>
    /// ULEB128 index into the FUNCTION_HANDLES table of the generic function for this instantiation (e.g., f<K, W>())
    /// </summary>
    public ulong FunctionHandle { get; set; }

    /// <summary>
    /// ULEB128 index into the SIGNATURES table for the instantiation of the function
    /// </summary>
    public ulong Instantiation { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadULEB128(out var functionHandle))
            return false;

        if (!reader.TryReadULEB128(out var instantiation))
            return false;

        FunctionHandle = functionHandle;
        Instantiation = instantiation;

        return true;
    }
}