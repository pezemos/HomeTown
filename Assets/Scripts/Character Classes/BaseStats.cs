public class BaseStats
{
    private int baseValue; // the base value of this statistic
    private int buffValue;
    private int expToLevel; // total amount of xp needed to level up this skill
    private float levelModifier;

    public BaseStats()
    {
        baseValue = 0;
        buffValue = 0;
        expToLevel = 100;
        levelModifier = 1.1f;
    }

    public int BaseValue
    {
        get { return baseValue; } 
        set { baseValue = value; }
    }

    public int BuffValue
    {
        get { return buffValue; }
        set { buffValue = value; }
    }

    public int ExpToLevel
    {
        get { return expToLevel; }
        set { expToLevel = value; }
    }

    public float LevelModifier
    {
        get { return levelModifier; }
        set { levelModifier = value; }
    }

    private int CalculateExpToLevel() 
    {
        return (int)(expToLevel*levelModifier);
    }

    public void LevelUp()
    {
        expToLevel = CalculateExpToLevel();
        baseValue++;
    }

    public int AdjustedBaseValue
    {
        get { return baseValue + buffValue; }    
    }
}
