namespace Explorer.ObjectTypes.Signature;

public class StructInstantiationToken : Token
{
    public StructInstantiationToken(Token[] substitutionTypes, long structHandleIndex)
    {
        SubstitutionTypes = substitutionTypes;
        StructHandleIndex = structHandleIndex;
    }

    public override TokenType Type => TokenType.StructInstantiation;

    public long StructHandleIndex { get; set; }
    public Token[] SubstitutionTypes { get; set; }
}