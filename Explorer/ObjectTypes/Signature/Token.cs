namespace Explorer.ObjectTypes.Signature;

[InterfaceType]
public abstract class Token
{
    public abstract TokenType Type { get; }
}