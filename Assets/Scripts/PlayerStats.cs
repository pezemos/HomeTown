using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    #region variables
    private PlayerHealthManager _thePlayerHealth;
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;


    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefence;

    #endregion

    // Use this for initialization
    void Start()
    {
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];

        _thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= expToLevelUp[currentLevel])
        {
            LevelUp();
        }
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }


    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];

        _thePlayerHealth.playerMaxHealth = currentHP;
        _thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentLevel - 1];

        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }

}
