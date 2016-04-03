using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    #region variables
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;

    // We want to see current gold in inspector, but dont want to let other scripts to change currentGold value
    [SerializeField]
    private int currentGold;

    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;

    public int maxHP;
    public int currentHP;
    public int currentAttack;
    public int currentDefence;

    private bool _flashActive;
    [SerializeField]
    private float flashLength;

    private float _flashCounter;

    private SpriteRenderer _playerSprite;
    #endregion

    // Use this for initialization
    void Start()
    {
        maxHP = HPLevels[currentLevel];
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];

        _playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= expToLevelUp[currentLevel])
        {
            LevelUp();
        }

        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
        }

        // Showing player damage
        if (_flashActive)
        {
            if (_flashCounter > flashLength * 0.66f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g,
                                      _playerSprite.color.b, 0f);
            }
            else if (_flashCounter > flashLength * 0.33f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g,
                                      _playerSprite.color.b, 1f);
            }
            else if (_flashCounter > 0f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g,
                                      _playerSprite.color.b, 0f);
            }
            else
            {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g,
                                      _playerSprite.color.b, 1f);
                _flashActive = false;
            }

            _flashCounter -= Time.deltaTime;
        }
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }

    public void AddGold(int goldToGive)
    {
        currentGold += goldToGive;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];

        maxHP = HPLevels[currentLevel];
        //currentHP += currentHP - HPLevels[currentLevel - 1];

        currentAttack += attackLevels[currentLevel];
        currentDefence += defenceLevels[currentLevel];
    }

    public void UpdateStats()
    {
        maxHP = HPLevels[currentLevel];

        //currentAttack = attackLevels[currentLevel];
        //currentDefence = defenceLevels[currentLevel];
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHP -= damageToGive;

        _flashActive = true;
        _flashCounter = flashLength;
    }

    public void SetMaxHealth()
    {
        currentHP = maxHP;
    }

    public void HealPlayer(int amountToHeal)
    {
        currentHP += amountToHeal;
    }

}
