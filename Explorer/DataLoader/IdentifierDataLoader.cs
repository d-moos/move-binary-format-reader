using System.Collections.ObjectModel;
using Explorer.BinaryRepository;
using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class IdentifierDataLoader : MoveFileDataLoader<Identifier>
{
    public IdentifierDataLoader(IBatchScheduler batchScheduler, IBinaryRepository binaryRepository, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.Identifiers, binaryRepository, options)
    {
    }
}