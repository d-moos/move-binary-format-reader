using MoveBinaryReader;
using MoveBinaryReader.Models;
using MoveBinaryReader.Models.FunctionDefinition;
using MoveBinaryReader.Models.Signature;
using ModuleHandle = MoveBinaryReader.Models.ModuleHandle;

namespace MoveBinaryReaderTests;

public class MoveReaderSmokeTest : BaseSmokeTest
{
    [GenericTestCase(typeof(ModuleHandle), TableKind.ModuleHandles)]
    [GenericTestCase(typeof(StructHandle), TableKind.StructHandles)]
    [GenericTestCase(typeof(FunctionHandle), TableKind.FunctionHandles)]
    [GenericTestCase(typeof(FunctionInstantiation), TableKind.FunctionInstantiations)]
    [GenericTestCase(typeof(Signature), TableKind.Signatures)]
    [GenericTestCase(typeof(Constant), TableKind.ConstantPool)]
    [GenericTestCase(typeof(Identifier), TableKind.Identifiers)]
    [GenericTestCase(typeof(AddressIdentifier), TableKind.AddressIdentifiers)]
    [GenericTestCase(typeof(StructDefinition), TableKind.StructDefinitions)]
    [GenericTestCase(typeof(StructDefInstantiation), TableKind.StructDefInstantiations)]
    [GenericTestCase(typeof(FunctionDefinition), TableKind.FunctionDefinitions)]
    [GenericTestCase(typeof(FieldHandle), TableKind.FieldHandles)]
    [GenericTestCase(typeof(FieldInstantiation), TableKind.FieldInstantiations)]
    [GenericTestCase(typeof(FriendDeclaration), TableKind.FriendDecls)]
    public void CanParseTable<T>(TableKind tableKind) where T : IReadableMoveModel, new()
    {
        var range = GetTableRange(tableKind);
        var result = MoveReader.TryReadModelCollectionInRange<T>(out var model, range.Start, range.End);
        
        Assert.IsTrue(result);
    }
}