using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class AddressDataLoader : MoveFileDataLoader<AddressIdentifier>
{
    public AddressDataLoader(IBatchScheduler batchScheduler, IMoveFile moveFile, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.AddressIdentifiers, moveFile, options)
    {
    }
}