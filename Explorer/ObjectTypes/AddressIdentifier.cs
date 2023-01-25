using Explorer.ObjectTypes.Signature;

namespace Explorer.ObjectTypes;

public record AddressIdentifier(string address);

public record Constant(Token Token, byte[] SerializedValue);