namespace Explorer.ObjectTypes.Signature;

public class MutableReferenceToken : Token
{
    public MutableReferenceToken(Token referencedType)
    {
        ReferencedType = referencedType;
    }
    
    public override TokenType Type => TokenType.MutableReference;
    
    public Token ReferencedType { get; set; }
}