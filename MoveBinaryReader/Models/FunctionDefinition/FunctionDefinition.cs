namespace MoveBinaryReader.Models.FunctionDefinition;

public struct FunctionDefinition : IReadableMoveModel
{
    public ulong FunctionHandle { get; set; }
    public Visibility Visibility { get; set; }
    public Flag Flag { get; set; }
    public AcquiredGlobalResources AcquiredGlobalResources { get; set; }
    public CodeUnit? CodeUnit { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModel<ULEB128>(out var functionHandle))
            return false;

        if (!reader.TryRead<Visibility>(out var visibility))
            return false;

        if (!reader.TryRead<Flag>(out var flag))
            return false;

        if (!reader.TryReadModel<AcquiredGlobalResources>(out var acquiredGlobalResources))
            return false;

        FunctionHandle = functionHandle;
        Visibility = visibility;
        Flag = flag;
        AcquiredGlobalResources = acquiredGlobalResources;
        
        if (Flag == Flag.Native)
            return true;

        if (!reader.TryReadModel<CodeUnit>(out var codeUnit))
            return false;

        CodeUnit = codeUnit;

        return true;
    }
}