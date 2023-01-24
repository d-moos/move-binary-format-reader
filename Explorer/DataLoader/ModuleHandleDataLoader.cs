using MoveBinaryReader.Models;
using ModuleHandle = MoveBinaryReader.Models.ModuleHandle;

namespace Explorer.DataLoader;

public class ModuleHandleDataLoader : MoveFileDataLoader<ModuleHandle>
{
    public ModuleHandleDataLoader(IBatchScheduler batchScheduler, IMoveFile moveFile, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.ModuleHandles, moveFile, options)
    {
    }
}