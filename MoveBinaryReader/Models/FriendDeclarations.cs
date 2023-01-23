namespace MoveBinaryReader.Models;

public struct FriendDeclarations : IReadableMoveModel
{
    public ulong Address { get; set; }
    public ulong Name { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadULEB128(out var address))
            return false;
        
        if (!reader.TryReadULEB128(out var name))
            return false;

        Address = address;
        Name = name;

        return true;
    }
}