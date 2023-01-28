namespace MoveBinaryReader.Models.FunctionDefinition;

public struct CodeUnit : IReadableMoveModel
{
    public ulong Locals { get; set; }
    public ByteCode[] Codes { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModel<ULEB128>(out var locals))
            return false;

        if (!reader.TryReadModelVector<ByteCode>(out var codes))
            return false;

        Locals = locals;
        Codes = codes;

        return true;
    }
}