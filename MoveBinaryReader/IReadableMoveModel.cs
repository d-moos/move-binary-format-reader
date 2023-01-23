namespace MoveBinaryReader;

public interface IReadableMoveModel
{
    bool TryRead(IMoveReader reader);
}