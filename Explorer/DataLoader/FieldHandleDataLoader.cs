using Explorer.BinaryRepository;
using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class FieldHandleDataLoader : MoveFileDataLoader<FieldHandle>
{
    public FieldHandleDataLoader(IBatchScheduler batchScheduler, IBinaryRepository binaryRepository, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.FieldHandles, binaryRepository, options)
    {
    }
}