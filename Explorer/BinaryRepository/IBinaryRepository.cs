namespace Explorer.BinaryRepository;

public interface IBinaryRepository
{
    public Task<byte[]> Get(string package, string moduleName);
    public Task Add(string package);
}