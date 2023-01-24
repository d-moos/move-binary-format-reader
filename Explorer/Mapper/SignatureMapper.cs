using Explorer.ObjectTypes.Signature;
using MoveBinaryReader.Models.Signature;
using Signature = Explorer.ObjectTypes.Signature.Signature;

namespace Explorer.Mapper;

public static class SignatureMapper
{
    public static Signature ToObjectType(this MoveBinaryReader.Models.Signature.Signature signature) =>
        new(signature.SignatureTokens.Select(x => x.ToObjectType()).ToArray());

    public static Token ToObjectType(this SignatureToken signatureToken)
        => signatureToken.SignatureTokenType switch
        {
            SignatureTokenType.Boolean => new BooleanToken(),
            SignatureTokenType.U8 => new U8Token(),
            SignatureTokenType.U64 => new U64Token(),
            SignatureTokenType.U128 => new U128Token(),
            SignatureTokenType.Address => new AddressToken(),
            SignatureTokenType.Reference => new ReferenceToken(
                ((SignatureToken)signatureToken.AdditionalPayload[0]).ToObjectType()
            ),
            SignatureTokenType.MutableReference => new MutableReferenceToken(
                ((SignatureToken)signatureToken.AdditionalPayload[0]).ToObjectType()
            ),
            SignatureTokenType.Struct => new StructToken(Convert.ToInt64(signatureToken.AdditionalPayload[0])),
            SignatureTokenType.TypeParameter => new TypeParameterToken(
                Convert.ToInt64(signatureToken.AdditionalPayload[0])),
            SignatureTokenType.Vector => new VectorToken(
                ((SignatureToken)signatureToken.AdditionalPayload[0]).ToObjectType()
            ),
            SignatureTokenType.StructInstantiation => new StructInstantiationToken(
                signatureToken.AdditionalPayload[1..].Select(x => ((SignatureToken)x).ToObjectType()).ToArray(),
                Convert.ToInt64(signatureToken.AdditionalPayload[0])
            ),
            SignatureTokenType.Signer => new SignerToken(),
            SignatureTokenType.U16 => new U16Token(),
            SignatureTokenType.U32 => new U32Token(),
            SignatureTokenType.U256 => new U256Token(),
            _ => throw new ArgumentOutOfRangeException()
        };
}