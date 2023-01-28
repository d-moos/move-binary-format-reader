using System.Text;

namespace MoveBinaryReader.Models;

public struct Identifier : IReadableMoveModel
{
    public string Value { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryReadVector<byte>(out var chars)) 
            return false;

        Value = Encoding.ASCII.GetString(chars);
        return true;
    }
}