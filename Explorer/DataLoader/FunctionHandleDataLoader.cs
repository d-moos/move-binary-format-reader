using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class FunctionHandleDataLoader : MoveFileDataLoader<FunctionHandle>
{
    public FunctionHandleDataLoader(IBatchScheduler batchScheduler, IMoveFile moveFile, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.FunctionHandles, moveFile, options)
    {
    }
}