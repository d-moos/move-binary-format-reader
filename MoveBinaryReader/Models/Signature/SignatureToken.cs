namespace MoveBinaryReader.Models.Signature;

public struct SignatureToken : IReadableMoveModel
{
    public SignatureTokenType SignatureTokenType { get; set; }
    public object[] AdditionalPayload { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryRead<SignatureTokenType>(out var signatureTokenType))
            return false;

        SignatureTokenType = signatureTokenType;

        switch (SignatureTokenType)
        {
            case SignatureTokenType.Reference:
            case SignatureTokenType.MutableReference:
            case SignatureTokenType.Vector:
                if (!reader.TryReadModel<SignatureToken>(out var additionalSignatureToken))
                    return false;

                AdditionalPayload = new[] { (object)additionalSignatureToken };
                break;
            
            case SignatureTokenType.TypeParameter:
            case SignatureTokenType.Struct:
                if (!reader.TryReadModel<ULEB128>(out var additionalUleb))
                    return false;

                AdditionalPayload = new[] { (object)additionalUleb };
                break;
            
            case SignatureTokenType.StructInstantiation:
                if (!reader.TryReadModel<ULEB128>(out var structHandleIndex))
                    return false;

                if (!reader.TryReadModelVector<SignatureToken>(out var substitutionTypes))
                    return false;

                var payload = new List<object>
                {
                    structHandleIndex
                };
                payload.AddRange(substitutionTypes.Select(x => (object)x));

                AdditionalPayload = payload.ToArray();
                
                break;
            default:
                AdditionalPayload = Array.Empty<object>();
                break;
        }

        return true;
    }
}