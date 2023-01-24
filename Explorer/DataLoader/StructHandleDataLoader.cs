using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class StructHandleDataLoader : MoveFileDataLoader<StructHandle>
{
    public StructHandleDataLoader(IBatchScheduler batchScheduler, IMoveFile moveFile, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.StructHandles, moveFile, options)
    {
    }
}