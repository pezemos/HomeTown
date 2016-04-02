using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    private int _currentDamage;

    public GameObject damageNumber;

    public float cooldown; //cooldown var(the one set from the editor, to be a fixed value for the cooldown)
    private float attackCooldown; // the cooldown value that varies
    private bool ableToAttack; // if the slime is able to attack

    private PlayerStats _thePlayerStats;
    void Start()
    {
        _thePlayerStats = FindObjectOfType<PlayerStats>();
        ableToAttack = true; // ableToAttack starts returning true so the slime can hit the player immediatelly after colliding with it
        attackCooldown = cooldown; // sets the attackCooldown float equal to the one set from the editor
    }

    void FixedUpdate()
    {
        if (ableToAttack == false)
        {
            attackCooldown -= Time.deltaTime; //the countdown operation
            if (attackCooldown < 0) // if the countdown time passed...
            {
                ableToAttack = true; // slime is able to attack
                attackCooldown = cooldown; // and the attackCooldown is set to the cooldown set in the inspector again
                print(name + " is ready to attack!"); // just prints into the console to detect bugs
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (ableToAttack == true) // if the slime is able to attack...
            {
                _currentDamage = damageToGive - _thePlayerStats.currentDefence;

                if (_currentDamage <= 0)
                {
                    _currentDamage = 1;
                }

                other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(_currentDamage);
                Debug.Log("Dame dealt " + _currentDamage + " from " + gameObject.name);

                var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<FloatingNumbers>().damageNumber = _currentDamage;

                ableToAttack = false; // after attacking the cooldown needs to run again before attacking again
            }
        }
    }
}