namespace MoveBinaryReader;

public interface IMoveReader
{
    ushort ReadPosition { get; set; }
    bool TryReadULEB128(out ulong value);
    bool TryRead<T>(out T value) where T : unmanaged;
    bool TryReadBool(out bool value);
    bool TryReadUleb128Collection<T>(out T[] value) where T : unmanaged;
    bool TryReadUleb128ModelCollection<T>(out T[] value) where T : IReadableMoveModel, new();
    bool TryReadModelCollection<T>(out T[] value, ulong length) where T : IReadableMoveModel, new();
    bool TryReadCollection<T>(out T[] value, ulong length) where T : unmanaged;
    bool TryReadModelCollectionInRange<T>(out T[] value, ushort start, ushort end) where T : IReadableMoveModel, new();
    bool TryRead<T>(Span<T> values) where T : unmanaged;
    bool TryRead(out string value);
    bool TryReadModel<T>(out T model) where T : IReadableMoveModel, new();
}