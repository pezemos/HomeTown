using System.Collections.Generic;

public class ModifiedStat :  BaseStats
{
    // List of attributes that modify this stat
    private List<ModifyingAttribute> mods;
    private int modValue; // The ammount added to the base value from modifiers

    public ModifiedStat()
    {
        mods = new List<ModifyingAttribute>();
        modValue = 0;
    }

    public void AddModifier(ModifyingAttribute mod)
    {
        mods.Add(mod); // Adding mod to ModyfingAttribute List
    }

    private void CalculateModValue()
    {
        modValue = 0; // Reseting value to 0

        if (mods.Count > 0) // If our list is greater than 0
        {
            foreach (ModifyingAttribute att in mods) // We are searching attributes in mods list
            {
                modValue += (int)(att.attribute.AdjustedBaseValue* att.ratio); 
            }
        }
    }

    public new int AdjustedBaseValue
    {
        get { return BaseValue + BuffValue + modValue; }
    }

    public void Update()
    {
        CalculateModValue(); 
    }
}

public struct ModifyingAttribute
{
    public Attribute attribute;
    public float ratio;

    public ModifyingAttribute(Attribute att, float rat)
    {
        attribute = att;
        ratio = rat;
    }
}
