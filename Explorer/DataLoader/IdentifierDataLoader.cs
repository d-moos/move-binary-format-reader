using System.Collections.ObjectModel;
using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class IdentifierDataLoader : MoveFileDataLoader<Identifier>
{
    public IdentifierDataLoader(IBatchScheduler batchScheduler, IMoveFile moveFile, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.Identifiers, moveFile, options)
    {
    }
}