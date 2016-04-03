using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;

    public Text levelText;

    public PlayerStats _thePlayerStats;

    private static bool _uiExists;

    // Use this for initialization
    void Start ()
    {

        // Checking if UI Exists
        if (!_uiExists)
        {
            _uiExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
        // Updating health bar
        //healthBar.maxValue = playerHealth.playerMaxHealth;
        //healthBar.value = playerHealth.playerCurrentHealth;
	    HPText.text = "HP: " + _thePlayerStats.currentHP + "/" + _thePlayerStats.HPLevels[_thePlayerStats.currentLevel];
        healthBar.maxValue = _thePlayerStats.HPLevels[_thePlayerStats.currentLevel];
	    healthBar.value = _thePlayerStats.currentHP;
        //HPText.text = "HP: " + _thePlayerStats.currentHP + "/" + _thePlayerStats.HPLevels[_thePlayerStats.currentLevel];


        // Updating level bar
        levelText.text = "Level: " + _thePlayerStats.currentLevel;
	}
}
