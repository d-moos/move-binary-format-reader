using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class StructDefinitionDataLoader : MoveFileDataLoader<StructDefinition>
{
    public StructDefinitionDataLoader(IBatchScheduler batchScheduler, IMoveFile moveFile, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.StructDefinitions, moveFile, options)
    {
    }
}