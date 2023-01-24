namespace Explorer.ObjectTypes.Signature;

public class VectorToken : Token
{
    public VectorToken(Token vectorType)
    {
        VectorType = vectorType;
    }

    public override TokenType Type => TokenType.Vector;
    
    public Token VectorType { get; set; }
}