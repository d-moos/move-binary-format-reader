using Explorer.ObjectTypes;

public class Query
{
    public Package GetPackage(string packageId)
    {
        return new Package(packageId);
    }
}