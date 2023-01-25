using Explorer.BinaryRepository;
using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class AddressIdentifierDataLoader : MoveFileDataLoader<AddressIdentifier>
{
    public AddressIdentifierDataLoader(IBatchScheduler batchScheduler, IBinaryRepository binaryRepository,
        DataLoaderOptions? options = null) : base(batchScheduler, TableKind.AddressIdentifiers, binaryRepository, options)
    {
    }
}