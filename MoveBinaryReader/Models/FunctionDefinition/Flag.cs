namespace MoveBinaryReader.Models.FunctionDefinition;

public enum Flag :byte
{
    Entry = 1 << 1,
    Native = 1 << 2
}