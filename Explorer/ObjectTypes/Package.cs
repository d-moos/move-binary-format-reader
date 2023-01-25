using Explorer.DataLoader;
using Explorer.Mapper;
using MoveBinaryReader;
using MoveBinaryReader.Models;
using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.Types;

namespace Explorer.ObjectTypes;

public record Package(string Id)
{
    [UseFiltering]
    public async Task<IQueryable<Module>> Modules([Service] IReadApi readApi)
    {
        var map = await readApi.GetRawObject(Id);

        return map.ExistsResult!.Data.ModuleMap!.Keys.Select(m => new Module(
            Id,
            m,
            Convert.FromBase64String(map.ExistsResult!.Data.ModuleMap[m].ToString()!))
        ).AsQueryable();
    }
}

public record Module(string PackageId, string Name, byte[] BinaryData)
{
    public Identifier[] Identifiers(IdentifierDataLoader dataLoader)
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.Identifier>(TableKind.Identifiers)
            .Select(x => x.ToObjectType())
            .ToArray();
    }

    public AddressIdentifier[] AddressIdentifiers()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.AddressIdentifier>(TableKind.AddressIdentifiers)
            .Select(x => x.ToObjectType())
            .ToArray();
    }

    public Signature.Signature[] Signatures()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.Signature.Signature>(TableKind.Signatures)
            .Select(x => x.ToObjectType())
            .ToArray();
    }

    public ModuleHandle[] ModuleHandles()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.ModuleHandle>(TableKind.ModuleHandles)
            .Select(x => x.ToObjectType($"{PackageId}::{Name}"))
            .ToArray();
    }

    public FunctionHandle[] FunctionHandles()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.FunctionHandle>(TableKind.FunctionHandles)
            .Select(x => x.ToObjectType($"{PackageId}::{Name}"))
            .ToArray();
    }

    public FunctionInstantiation[] FunctionInstantiations()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.FunctionInstantiation>(TableKind.FunctionInstantiations)
            .Select(x => x.ToObjectType($"{PackageId}::{Name}"))
            .ToArray();
    }

    public StructHandle[] StructHandles()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.StructHandle>(TableKind.StructHandles)
            .Select(x => x.ToObjectType($"{PackageId}::{Name}"))
            .ToArray();
    }


    public StructDefinition.StructDefinition[] StructDefinitions()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.StructDefinition>(TableKind.StructDefinitions)
            .Select(x => x.ToObjectType($"{PackageId}::{Name}"))
            .ToArray();
    }


    public FieldHandle[] FieldHandles()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.FieldHandle>(TableKind.FieldHandles)
            .Select(x => x.ToObjectType($"{PackageId}::{Name}"))
            .ToArray();
    }


    public FieldInstantiation[] FieldInstantiations()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.FieldInstantiation>(TableKind.FieldInstantiations)
            .Select(x => x.ToObjectType($"{PackageId}::{Name}"))
            .ToArray();
    }

    public StructDefInstantiation[] StructDefInstantiations()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.StructDefInstantiation>(TableKind.StructDefInstantiations)
            .Select(x => x.ToObjectType($"{PackageId}::{Name}"))
            .ToArray();
    }

    public FriendDeclaration[] FriendDeclarations()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.FriendDeclaration>(TableKind.FriendDecls)
            .Select(x => x.ToObjectType($"{PackageId}::{Name}"))
            .ToArray();
    }

    public Constant[] Constants()
    {
        var file = new MoveBinaryFile(BinaryData);
        return file
            .ReadTable<MoveBinaryReader.Models.Constant>(TableKind.ConstantPool)
            .Select(x => x.ToObjectType())
            .ToArray();
    }
}