namespace Explorer.ObjectTypes.Signature;

public class StructToken : Token
{
    public StructToken(long structHandleIndex)
    {
        StructHandleIndex = structHandleIndex;
    }

    public override TokenType Type => TokenType.Struct;

    public long StructHandleIndex { get; set; }
}