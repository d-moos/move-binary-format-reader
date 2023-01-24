namespace Explorer.ObjectTypes.Signature;

public enum TokenType
{
    Boolean = 0x01,
    U8 = 0x02,
    U64 = 0x03,
    U128 = 0x04,
    Address = 0x05,
    Reference = 0x06,
    MutableReference = 0x07,
    Struct = 0x08,
    TypeParameter = 0x09,
    Vector = 0x0A,
    StructInstantiation = 0x0B,
    Signer = 0x0C,
    U16 = 0x0D,
    U32 = 0x0E,
    U256 = 0x0F
}