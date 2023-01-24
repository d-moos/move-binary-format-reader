using MoveBinaryReader;
using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public abstract class MoveFileDataLoader<T> : BatchDataLoader<ulong, T> where T : IReadableMoveModel, new()
{
    private readonly IMoveFile _moveFile;
    private readonly TableKind _tableKind;
    
    protected MoveFileDataLoader(IBatchScheduler batchScheduler, TableKind tableKind, IMoveFile moveFile, DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
        _tableKind = tableKind;
        _moveFile = moveFile;
    }

    protected override async Task<IReadOnlyDictionary<ulong, T>> LoadBatchAsync(IReadOnlyList<ulong> keys, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var identifiers = _moveFile.ReadTable<T>(_tableKind);
        if (identifiers == null)
            return new Dictionary<ulong, T>();

        return identifiers
            .Select((v, i) => (v, i))
            .ToDictionary(t => (ulong)t.i, t => t.v);
    }
}