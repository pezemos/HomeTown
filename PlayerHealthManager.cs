using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;

    private bool _flashActive;
    public float flashLength;
    private float _flashCounter;

    private SpriteRenderer _playerSprite;

	// Use this for initialization
	void Start ()
	{
	    playerCurrentHealth = playerMaxHealth;
	    _playerSprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (playerCurrentHealth <= 0)
	    {
	        gameObject.SetActive(false);
	    }

        // Showing player damage
	    if (_flashActive)
	    {
	        if (_flashCounter > flashLength*0.66f)
	        {
                _playerSprite.color = new Color(_playerSprite.color.r, _playerSprite.color.g,
                                      _playerSprite.color.b, 0f);
            }
            else if (_flashCounter > flashLength*0.33f)
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

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;

        _flashActive = true;
        _flashCounter = flashLength;

    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void HealPlayer(int amountToHeal)
    {
        playerCurrentHealth += amountToHeal;
    }
}
