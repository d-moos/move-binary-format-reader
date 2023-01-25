using Explorer.BinaryRepository;
using MoveBinaryReader.Models;
using MoveBinaryReader.Models.Signature;

namespace Explorer.DataLoader;

public class SignatureDataLoader : MoveFileDataLoader<Signature>
{
    public SignatureDataLoader(IBatchScheduler batchScheduler, IBinaryRepository binaryRepository, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.Signatures, binaryRepository, options)
    {
    }
}