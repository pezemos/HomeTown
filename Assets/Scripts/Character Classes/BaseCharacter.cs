using UnityEngine;
using System.Collections;
using System;

public class BaseCharacter : MonoBehaviour
{

    private string characterName;
    private int level;
    private uint freeExp;

    private Attribute[] primaryAttribute;
    private Vital[] vital;
    private Skill[] skill;

    public string Name
    {
        get { return characterName; }
        set { characterName = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public uint FreeExp
    {
        get { return freeExp; }
        set { freeExp = value; }
    }

    public void Awake()
    {
        name = string.Empty;
        level = 0;
        freeExp = 0;

        // Getting the array length from enums size
        primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
        vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
        skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];
        
        SetupPrimaryAttributes();
        SetupSkills();
        SetupVitals();
    }   

    private void SetupPrimaryAttributes()
    {
        for (int i = 0; i < primaryAttribute.Length; i++)
        {
            primaryAttribute[i] = new Attribute();
        }
    }

    private void SetupVitals()
    {
        for (int i = 0; i < vital.Length; i++)
        {
            vital[i] = new Vital();
        }
    }

    private void SetupSkills()
    {
        for (int i = 0; i < skill.Length; i++)
        {
            skill[i] = new Skill();
        }
    }

    private void CalculateLevel()
    {
        
    }

    public void AddExp(uint exp)
    {
        freeExp += exp;

        CalculateLevel();
    }

    public Attribute GetPrimaryAttribute(int index)
    {
        return primaryAttribute[index];
    }

    public Vital GetVital(int index)
    {
        return vital[index];
    }

    public Skill GetSkill(int index)
    {
        return skill[index];
    }

    private void SetupVitalModifiers()
    {
        // health
        GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Vital), 0.5f));

        // mana
        GetVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Vital), 0.5f));
    }

    private void SetupSkillModifiers()
    {
        // Magic Defence
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Magic), 0.33f));
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Vital), 0.2f));
        // Magic Offence
        GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Magic), 0.33f));
        GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), 0.2f));
        // Melee Defence
        GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Vital), 0.33f));
        GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), 0.2f));
        // Melee Offence
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Vital), 0.2f));
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), 0.33f));
    }

    public void StatUpdate()
    {
        for (int i = 0; i < vital.Length; i++)
            vital[i].Update();

        for (int i = 0; i < skill.Length; i++)
            skill[i].Update();

        for (int i = 0; i < vital.Length; i++)
            vital[i].Update();
    }
}
