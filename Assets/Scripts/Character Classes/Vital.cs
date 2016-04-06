public class Vital : ModifiedStat
{
    private int currentValue;

    public Vital()
    {
        currentValue = 0;
        ExpToLevel = 100;
        LevelModifier = 1.1f;
    }

    public int CurrentValue
    {
        get
        {
            if (currentValue > AdjustedBaseValue)
                currentValue = AdjustedBaseValue;

            return currentValue;
        }
        set { currentValue = value; }
    }
}

public enum VitalName
{
    Health,
    Mana
}