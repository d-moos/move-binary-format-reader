namespace MoveBinaryReader.Models;

public struct StructTypeParameter : IReadableMoveModel
{
    public Ability Constraints { get; set; }
    public bool IsPhantom { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryRead<Ability>(out var constraints))
            return false;
        
        if (!reader.TryReadBool(out var isPhantom))
            return false;

        Constraints = constraints;
        IsPhantom = isPhantom;
        
        return true;
    }
}