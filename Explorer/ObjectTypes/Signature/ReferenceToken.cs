namespace Explorer.ObjectTypes.Signature;

public class ReferenceToken : Token
{
    public ReferenceToken(Token referencedType)
    {
        ReferencedType = referencedType;
    }

    public override TokenType Type => TokenType.Reference;

    public Token ReferencedType { get; set; }
}