namespace MoveBinaryReader.Models.Signature;

public struct Signature : IReadableMoveModel
{
    public SignatureToken[] SignatureTokens { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadUleb128ModelCollection<SignatureToken>(out var signatureTokens))
            return false;

        SignatureTokens = signatureTokens;

        return true;
    }
}