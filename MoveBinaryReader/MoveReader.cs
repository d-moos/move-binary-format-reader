using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace MoveBinaryReader;

public class MoveReader : IMoveReader
{
    private readonly Memory<byte> _data;

    public ushort ReadPosition { get; set; }

    public MoveReader(Memory<byte> data)
    {
        _data = data;
    }

    public bool TryReadULEB128(out ulong value)
    {
        value = default;

        ulong val = 0;
        var shift = 0;
        var more = true;

        while (more)
        {
            var nextResult = TryRead<byte>(out var next);
            if (!nextResult)
                throw new InvalidOperationException("Unexpected end of stream");

            byte b = (byte)next;

            more = (b & 0x80) != 0; // extract msb
            ulong chunk = b & 0x7fUL; // extract lower 7 bits
            val |= chunk << shift;
            shift += 7;
        }

        value = val;
        return true;
    }

    public bool TryRead<T>(out T value) where T : unmanaged
    {
        var size = (ushort)Unsafe.SizeOf<T>();
        if (ReadPosition + size > _data.Length)
        {
            value = default;
            return false;
        }

        if (MemoryMarshal.TryRead(_data.Span.Slice(ReadPosition), out value))
        {
            ReadPosition += size;
            return true;
        }

        return false;
    }

    public bool TryReadBool(out bool value)
    {
        value = default;
        
        var size = (ushort)Unsafe.SizeOf<bool>();
        if (ReadPosition + size > _data.Length)
        {
            value = default;
            return false;
        }

        
        if (MemoryMarshal.TryRead(_data.Span.Slice(ReadPosition), out byte boolAsByte))
        {
            ReadPosition += size;
            if (boolAsByte > 0x01)
                return false;

            value = boolAsByte != 0x00;
            return true;
        }

        return false;
    }

    public bool TryReadUleb128Collection<T>(out T[] value) where T : unmanaged
    {
        value = Array.Empty<T>();

        if (!TryReadULEB128(out var length))
            return false;

        if (length == 0)
            return true;

        return TryReadCollection(out value, length);
    }

    public bool TryReadUleb128ModelCollection<T>(out T[] value) where T : IReadableMoveModel, new()
    {
        value = Array.Empty<T>();

        if (!TryReadULEB128(out var length))
            return false;

        if (length == 0)
            return true;

        return TryReadModelCollection(out value, length);
    }

    public bool TryReadModelCollection<T>(out T[] value, ulong length) where T : IReadableMoveModel, new()
    {
        value = Array.Empty<T>();
        
        var typeParameters = new List<T>();
        for (ulong i = 0; i < length; i++)
        {
            if (!TryReadModel<T>(out var typeParameterKind))
                return false;

            typeParameters.Add(typeParameterKind);
        }

        value = typeParameters.ToArray();
        return true;
    }
    
    public bool TryReadCollection<T>(out T[] value, ulong length) where T : unmanaged
    {
        value = Array.Empty<T>();
        
        var values = new List<T>();
        for (ulong i = 0; i < length; i++)
        {
            if (!TryRead<T>(out var val))
                return false;

            values.Add(val);
        }

        value = values.ToArray();
        return true;
    }

    public bool TryReadModelCollectionInRange<T>(out T[] value, ushort start, ushort end) where T : IReadableMoveModel, new()
    {
        value = Array.Empty<T>();
        ReadPosition = start;
        var values = new List<T>();
        
        while (ReadPosition < end)
        {
            if (!TryReadModel(out T model))
                return false;

            values.Add(model);
        }

        if (ReadPosition != end)
            return false;

        value = values.ToArray();
        return true;
    }

    public bool TryRead<T>(Span<T> values) where T : unmanaged
    {
        var valueBytes = MemoryMarshal.AsBytes(values);

        ushort size = (ushort)valueBytes.Length;
        if (this.ReadPosition + size > _data.Length)
            return false;

        if (_data.Span.Slice(this.ReadPosition, size).TryCopyTo(valueBytes))
        {
            this.ReadPosition += size;
            return true;
        }

        return false;
    }
    

    public bool TryRead(out string value)
    {
        if (!TryRead<byte>(out var length))
        {
            value = default;
            return false;
        }

        if (this.ReadPosition + length > _data.Length)
        {
            value = null;
            return false;
        }

        value = Encoding.ASCII.GetString(_data.Span.Slice(this.ReadPosition, length));
        ReadPosition += length;
        return true;
    }

    public bool TryReadModel<T>(out T model) where T : IReadableMoveModel, new()
    {
        model = new T();
        return model.TryRead(this);
    }
}