namespace Explorer.ObjectTypes.Signature;

public class TypeParameterToken : Token
{
    public TypeParameterToken(long typeParametersIndex)
    {
        TypeParametersIndex = typeParametersIndex;
    }

    public override TokenType Type => TokenType.TypeParameter;
    
    // ?? wat
    public long TypeParametersIndex { get; set; }
}