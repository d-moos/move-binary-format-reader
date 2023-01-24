using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class FieldHandleDataLoader : MoveFileDataLoader<FieldHandle>
{
    public FieldHandleDataLoader(IBatchScheduler batchScheduler, IMoveFile moveFile, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.FieldHandles, moveFile, options)
    {
    }
}