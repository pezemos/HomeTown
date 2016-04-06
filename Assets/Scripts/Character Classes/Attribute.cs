public class Attribute : BaseStats {

    public Attribute()
    {
        ExpToLevel = 50;
        LevelModifier = 1.05f;
    }
}

public enum AttributeName
{
    Strength,
    Vital,
    Speed,
    Charisma,
    Magic
}
