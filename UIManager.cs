using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    public Text MoneyText;
    public Text levelText;

    private PlayerStats _thePlayerStats;
    private static bool _uiExists;

    // Use this for initialization
    void Start ()
    {
        _thePlayerStats = GetComponent<PlayerStats>();

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
	    healthBar.maxValue = playerHealth.playerMaxHealth;
	    healthBar.value = playerHealth.playerCurrentHealth;
	    HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
	   

        // Updating level bar
	    levelText.text = "Level: " + _thePlayerStats.currentLevel;
        // Updating money bar
        MoneyText.text = "Money: " + _thePlayerStats.currentGold;


    }
}
