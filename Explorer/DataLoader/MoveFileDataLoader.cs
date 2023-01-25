using System.Security;
using Explorer.BinaryRepository;
using MoveBinaryReader;
using MoveBinaryReader.Models;

namespace Explorer.DataLoader;

public abstract class MoveFileDataLoader<T> : BatchDataLoader<(string moduleIdentifier, ulong Index), T> where T : IReadableMoveModel, new()
{
    private readonly IBinaryRepository _binaryRepository;
    private readonly TableKind _tableKind;
    
    protected MoveFileDataLoader(IBatchScheduler batchScheduler, TableKind tableKind, IBinaryRepository binaryRepository, DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
        _tableKind = tableKind;
        _binaryRepository = binaryRepository;
    }

    protected override async Task<IReadOnlyDictionary<(string, ulong), T>> LoadBatchAsync(IReadOnlyList<(string, ulong)> keys, CancellationToken cancellationToken)
    {
        var entries = new Dictionary<(string, ulong), T>();
        var moduleIdentifierMap = keys.GroupBy(x => x.Item1);
        foreach (var grouping in moduleIdentifierMap)
        {
            // ModuleIdentifier
            var identifiers2 = grouping.Key.Split("::");
            var data = await _binaryRepository.Get(identifiers2[0], identifiers2[1]);
            var binaryFile2 = new MoveBinaryFile(data);
            var allEntries = binaryFile2.ReadTable<T>(_tableKind);
            var relevantEntries = grouping.Select(x => x.Item2);
            
            foreach (var relevantEntry in relevantEntries)
            {
                var entry = allEntries.ElementAt((int)relevantEntry);
                entries.Add((grouping.Key, relevantEntry), entry);
            }
        }

        return entries;
        
        
        var moduleData = await _binaryRepository.Get("", "");
        var binaryFile = new MoveBinaryFile(moduleData);

        var keyMap = keys
            .DistinctBy(x => x.Item2)
            .ToDictionary(x => x.Item2, x => x.Item1);
        
        var identifiers = binaryFile.ReadTable<T>(_tableKind);
        if (identifiers == null)
            return new Dictionary<(string, ulong), T>();

        return identifiers
            .Select((v, i) => (v, i))
            .ToDictionary(t => (keyMap[(ulong)t.i], (ulong)t.i), t => t.v);
    }
}