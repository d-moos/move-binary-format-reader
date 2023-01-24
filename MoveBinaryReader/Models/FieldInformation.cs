namespace MoveBinaryReader.Models;

public struct FieldInformation : IReadableMoveModel
{
    public Tag Tag { get; set; }
    public ulong FieldCount { get; set; }
    public Field[] Fields { get; set; }
    
    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryRead<Tag>(out var tag))
            return false;

        if (!reader.TryReadULEB128(out var fieldCount))
            return false;

        if (!reader.TryReadModelCollection<Field>(out var fields, fieldCount))
            return false;
        
        Tag = tag;
        FieldCount = fieldCount;
        Fields = fields;
        
        return true;
    }
}