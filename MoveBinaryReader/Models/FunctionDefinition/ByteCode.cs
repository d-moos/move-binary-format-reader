namespace MoveBinaryReader.Models.FunctionDefinition;

public struct ByteCode : IReadableMoveModel
{
    public Opcode Opcode { get; set; }
    public object? Payload { get; set; }

    public bool TryRead(IMoveReader reader)
    {
        if (!reader.TryRead<Opcode>(out var opcode))
            return false;
        
        Opcode = opcode;
        
        switch (opcode)
        {
            case Opcode.BrTrue:
            case Opcode.BrFalse:
            case Opcode.Branch:
            case Opcode.LdConst:
            case Opcode.CopyLoc:
            case Opcode.MoveLoc:
            case Opcode.StLoc:
            case Opcode.MutBorrowLoc:
            case Opcode.ImmBorrowLoc:
            case Opcode.MutBorrowField:
            case Opcode.ImmBorrowField:
            case Opcode.Call:
            case Opcode.Pack:
            case Opcode.Unpack:
            case Opcode.Exists:
            case Opcode.MutBorrowGlobal:
            case Opcode.ImmBorrowGlobal:
            case Opcode.MoveFrom:
            case Opcode.MoveTo:
            case Opcode.MutBorrowFieldGeneric:
            case Opcode.ImmBorrowFieldGeneric:
            case Opcode.CallGeneric:
            case Opcode.PackGeneric:
            case Opcode.UnpackGeneric:
            case Opcode.ExistsGeneric:
            case Opcode.MutBorrowGlobalGeneric:
            case Opcode.ImmBorrowGlobalGeneric:
            case Opcode.MoveFromGeneric:
            case Opcode.MoveToGeneric:
            case Opcode.VecLen:
            case Opcode.VecImmBorrow:
            case Opcode.VecMutBorrow:
            case Opcode.VecPushBack:
            case Opcode.VecPopBack:
            case Opcode.VecSwap:
                if (!reader.TryReadModel<ULEB128>(out var index))
                    return false;
                Payload = index;
                break;
            case Opcode.LdU64:
                if (!reader.TryRead<ulong>(out var u64Value))
                    return false;
                Payload = u64Value;
                break;
            case Opcode.LdU8:
                if (!reader.TryRead<byte>(out var u8Value))
                    return false;
                Payload = u8Value;
                break;
            case Opcode.LdU16:
                if (!reader.TryRead<ushort>(out var u16Value))
                    return false;
                Payload = u16Value;
                break;
            case Opcode.LdU32:
                if (!reader.TryRead<uint>(out var u32Value))
                    return false;
                Payload = u32Value;
                break;
            case Opcode.LdU256:
                var u256 = new byte[32];
                
                if (!reader.TryRead(u256.AsSpan()))
                    return false;
                Payload = u256;
                break;
            case Opcode.LdU128:
                var u128 = new byte[16];
                
                if (!reader.TryRead(u128.AsSpan()))
                    return false;
                Payload = u128;
                break;
            case Opcode.VecPack:
            case Opcode.VecUnpack:
                if (!reader.TryReadModel<ULEB128>(out var s))
                    return false;
                if (!reader.TryRead<ulong>(out var elementLen))
                    return false;
                
                Payload = new[] {(ulong)s, elementLen };
                break;
        }
        
        return true;
    }
}