using Explorer.ObjectTypes;

namespace Explorer.Mapper;

public static class FriendDeclarationsMapper
{
    public static FriendDeclaration ToObjectType(this MoveBinaryReader.Models.FriendDeclaration friendDeclaration, string moduleIdentifier)
        => new(
            Convert.ToInt64(friendDeclaration.Address),
            Convert.ToInt64(friendDeclaration.Name),
            moduleIdentifier
        );
}