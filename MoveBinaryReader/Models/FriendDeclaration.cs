namespace MoveBinaryReader.Models;

public struct FriendDeclaration : IReadableMoveModel
{
    public ulong Address { get; set; }
    public ulong Name { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadModel<ULEB128>(out var address))
            return false;
        
        if (!reader.TryReadModel<ULEB128>(out var name))
            return false;

        Address = address;
        Name = name;

        return true;
    }
}