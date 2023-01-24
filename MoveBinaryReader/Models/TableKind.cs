namespace MoveBinaryReader.Models;

public enum TableKind : byte
{
    ModuleHandles = 0x01,
    StructHandles = 0x02,
    FunctionHandles = 0x03,
    FunctionInstantiations = 0x04,
    Signatures= 0x05,
    ConstantPool = 0x06,
    Identifiers = 0x07,
    AddressIdentifiers = 0x08,
    StructDefinitions = 0x0A,
    StructDefInstantiations = 0x0B,
    FunctionDefinitions = 0x0C,
    FieldHandles = 0x0D,
    FieldInstantiations = 0x0E,
    FriendDecls = 0x0F
}