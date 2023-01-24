using Explorer.ObjectTypes.StructDefinition;

namespace Explorer.Mapper;

public static class StructDefinitionMapper
{
    public static StructDefinition ToObjectType(this MoveBinaryReader.Models.StructDefinition structDefinition)
        => new(Convert.ToInt64(structDefinition.StructHandle),
            structDefinition.FieldInformation.ToObjectType()
        );

    public static FieldInformation ToObjectType(this MoveBinaryReader.Models.FieldInformation fieldInformation)
        => new(
            fieldInformation.Tag.ToObjectType(),
            fieldInformation.Fields.Select(x => x.ToObjectType()).ToArray()
        );

    public static Tag ToObjectType(this MoveBinaryReader.Models.Tag tag) => tag switch
    {
        MoveBinaryReader.Models.Tag.Native => Tag.Native,
        MoveBinaryReader.Models.Tag.ContainsFields => Tag.ContainsFields,
        _ => throw new ArgumentOutOfRangeException(nameof(tag), tag, null)
    };

    public static Field ToObjectType(this MoveBinaryReader.Models.Field field) => new(
        Convert.ToInt64(field.Name),
        field.Type.ToObjectType()
    );
}