namespace MoveBinaryReader;

public interface IMoveReader
{
    ushort ReadPosition { get; set; }
    
    bool TryRead<T>(out T value) where T : unmanaged;
    bool TryReadBool(out bool value);
    bool TryReadVector<T>(out T[] value) where T : unmanaged;
    bool TryReadModelVector<T>(out T[] value) where T : IReadableMoveModel, new();
    bool TryReadModelCollection<T>(out T[] value, ulong length) where T : IReadableMoveModel, new();
    bool TryReadCollection<T>(out T[] value, ulong length) where T : unmanaged;
    bool TryReadModelCollectionInRange<T>(out T[] value, ushort start, ushort end) where T : IReadableMoveModel, new();
    bool TryRead<T>(Span<T> values) where T : unmanaged;
    bool TryReadModel<T>(out T model) where T : IReadableMoveModel, new();
}