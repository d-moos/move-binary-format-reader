using Explorer.BinaryRepository;
using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public class StructDefinitionDataLoader : MoveFileDataLoader<StructDefinition>
{
    public StructDefinitionDataLoader(IBatchScheduler batchScheduler, IBinaryRepository binaryRepository, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.StructDefinitions, binaryRepository, options)
    {
    }
}