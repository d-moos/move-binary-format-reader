using Explorer.BinaryRepository;
using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class StructHandleDataLoader : MoveFileDataLoader<StructHandle>
{
    public StructHandleDataLoader(IBatchScheduler batchScheduler, IBinaryRepository binaryRepository, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.StructHandles, binaryRepository, options)
    {
    }
}