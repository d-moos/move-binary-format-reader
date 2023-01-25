using Naami.SuiNet.Apis.Read;
using Naami.SuiNet.Types;
using ServiceStack;

namespace Explorer.BinaryRepository;

public class BinaryRepository : IBinaryRepository
{
    private readonly IReadApi _readApi;
    private readonly Dictionary<string, byte[]> _modules = new();

    public BinaryRepository(IReadApi readApi)
    {
        _readApi = readApi;
    }

    public async Task<byte[]> Get(string package, string moduleName)
    {
        var key = GetKey(package, moduleName);
        if (!_modules.ContainsKey(key))
            await Add(package);

        return _modules[key];
    }


    public async Task Add(string package)
    {
        if (_modules.ContainsKey(package))
            return;

        var packageObject = await _readApi.GetRawObject(package);
        if (packageObject.ObjectStatus != ObjectStatus.Exists)
            throw new Exception("package not found");

        foreach (var (moduleName, value) in packageObject.ExistsResult.Data.ModuleMap)
        {
            _modules.Add(GetKey(package, moduleName), Convert.FromBase64String(value.ToString()!));
        }
    }

    private string GetKey(string package, string module) => $"{package}::{module}";
}