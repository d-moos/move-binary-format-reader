namespace MoveBinaryReader.Models;

[Flags]
public enum Ability : byte
{
    Empty = 0x00,
    Copy = 1 << 1,
    Drop = 1 << 2,
    Store = 1 << 3,
    Key = 1 << 4,
}