using MoveBinaryReader;
using MoveBinaryReader.Models;

namespace Explorer;

public interface IMoveFile
{
    FileHeader FileHeader { get; }
    TableHeader TableHeader(TableKind kind);
    IReadOnlyCollection<T>? ReadTable<T>(TableKind kind) where T : IReadableMoveModel, new();
}