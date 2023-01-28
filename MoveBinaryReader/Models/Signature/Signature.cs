namespace MoveBinaryReader.Models.Signature;

public struct Signature : IReadableMoveModel
{
    public SignatureToken[] SignatureTokens { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModelVector<SignatureToken>(out var signatureTokens))
            return false;

        SignatureTokens = signatureTokens;

        return true;
    }
}