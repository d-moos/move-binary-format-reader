namespace MoveBinaryReader.Models.FunctionDefinition;

public struct CodeUnit : IReadableMoveModel
{
    public ulong Locals { get; set; }
    public ByteCode[] Codes { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadULEB128(out var locals))
            return false;

        if (!reader.TryReadUleb128ModelCollection<ByteCode>(out var codes))
            return false;

        Locals = locals;
        Codes = codes;

        return true;
    }
}