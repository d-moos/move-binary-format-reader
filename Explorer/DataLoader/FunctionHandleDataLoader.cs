using Explorer.BinaryRepository;
using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class FunctionHandleDataLoader : MoveFileDataLoader<FunctionHandle>
{
    public FunctionHandleDataLoader(IBatchScheduler batchScheduler, IBinaryRepository binaryRepository, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.FunctionHandles, binaryRepository, options)
    {
    }
}