public class Skill : ModifiedStat
{
    private bool known;

    public Skill()
    {
        known = false;
        ExpToLevel = 25;
        LevelModifier = 1.1f;
    }

    public bool Known
    {
        get { return known; }
        set { known = value; }
    }
}


public enum SkillName
{
    Melee_Offence,
    Melee_Defence,
    Magic_Offence,
    Magic_Defence
}