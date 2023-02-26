using MoveBinaryReader.Models.Signature;

namespace MoveBinaryReader.Models;

public struct Constant : IReadableMoveModel
{
    public SignatureToken SignatureToken { get; set; }
    public ULEB128 ValueLength { get; set; } // TODO: check
    public byte[] SerializedValue { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModel<SignatureToken>(out var signatureToken))
            return false;

        if (!reader.TryReadModel<ULEB128>(out var valueLength))
            return false;

        var span = new byte[valueLength];
        if (!reader.TryRead(span.AsSpan()))
            return false;

        SignatureToken = signatureToken;
        ValueLength = valueLength;
        SerializedValue = span;

        return true;
    }
}