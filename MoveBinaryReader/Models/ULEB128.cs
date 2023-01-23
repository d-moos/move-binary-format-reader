namespace MoveBinaryReader.Models;

public struct ULEB128 : IReadableMoveModel
{
    private const long SIGN_EXTEND_MASK = -1L;
    private const int INT64_BITSIZE = (sizeof(long) * 8);
        
    public ulong Value { get; set; }
        
    public bool TryRead(IMoveReader reader)
    {
        ulong val = 0;
        var shift = 0;
        var more = true;

        while (more)
        {
            var nextResult = reader.TryRead<byte>(out var next);
            if (!nextResult)
                return false;

            byte b = (byte)next;

            more = (b & 0x80) != 0; // extract msb
            ulong chunk = b & 0x7fUL; // extract lower 7 bits
            val |= chunk << shift;
            shift += 7;
        }

        Value = val;
        return true;
    }
}