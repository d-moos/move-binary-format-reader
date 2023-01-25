using Explorer.BinaryRepository;
using MoveBinaryReader.Models;
using ModuleHandle = MoveBinaryReader.Models.ModuleHandle;

namespace Explorer.DataLoader;

public class ModuleHandleDataLoader : MoveFileDataLoader<ModuleHandle>
{
    public ModuleHandleDataLoader(IBatchScheduler batchScheduler, IBinaryRepository binaryRepository, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.ModuleHandles, binaryRepository, options)
    {
    }
}