﻿using Explorer.ObjectTypes;

namespace Explorer.Mapper;

public static class StructHandleMapper
{
    public static StructHandle ToObjectType(this MoveBinaryReader.Models.StructHandle structHandle, string moduleIdentifier)
        => new(Convert.ToInt64(structHandle.Module),
            Convert.ToInt64(structHandle.Name),
            structHandle.NominalResource.ToObjectType(),
            structHandle.TypeParameters.Select(x => x.ToObjectType()).ToArray(),
            moduleIdentifier
        );

    public static StructTypeParameter ToObjectType(
        this MoveBinaryReader.Models.StructTypeParameter structTypeParameter
    ) => new(structTypeParameter.Constraints.ToObjectType(), structTypeParameter.IsPhantom);
}