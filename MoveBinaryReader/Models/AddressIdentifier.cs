using System.Text;

namespace MoveBinaryReader.Models;

public struct AddressIdentifier : IReadableMoveModel
{
    private const ulong AddressLength = 20;
    
    public byte[] Address { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadCollection<byte>(out var address, AddressLength))
            return false;

        Address = address;        
        return true;
    }
}