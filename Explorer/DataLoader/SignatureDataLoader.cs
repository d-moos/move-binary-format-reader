using MoveBinaryReader.Models;
using MoveBinaryReader.Models.Signature;

namespace Explorer.DataLoader;

public class SignatureDataLoader : MoveFileDataLoader<Signature>
{
    public SignatureDataLoader(IBatchScheduler batchScheduler, IMoveFile moveFile, DataLoaderOptions? options = null) : base(batchScheduler, TableKind.Signatures, moveFile, options)
    {
    }
}