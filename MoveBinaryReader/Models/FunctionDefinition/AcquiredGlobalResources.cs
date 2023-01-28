namespace MoveBinaryReader.Models.FunctionDefinition;

public struct AcquiredGlobalResources : IReadableMoveModel
{
    public ULEB128[] Resources { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModelVector<ULEB128>(out var resources))
            return false;

        Resources = resources;

        return true;
    }
}