using Explorer.ObjectTypes;

namespace Explorer.Mapper;

public static class AbilityMapper
{
    public static Ability[] ToObjectType(this MoveBinaryReader.Models.Ability abilityFlag)
    {
        var abilities = new List<Ability>();

        if ((abilityFlag & MoveBinaryReader.Models.Ability.Copy) != 0)
            abilities.Add(Ability.Copy);

        if ((abilityFlag & MoveBinaryReader.Models.Ability.Drop) != 0)
            abilities.Add(Ability.Drop);

        if ((abilityFlag & MoveBinaryReader.Models.Ability.Key) != 0)
            abilities.Add(Ability.Key);

        if ((abilityFlag & MoveBinaryReader.Models.Ability.Store) != 0)
            abilities.Add(Ability.Store);

        return abilities.ToArray();
    }
}