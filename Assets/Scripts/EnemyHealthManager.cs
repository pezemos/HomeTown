using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    public int experienceToGive;
    public int goldToGive;

    public GameObject enemyDrop;

    private PlayerStats _thePlayerStats;
    private Vector3 enemyPosistion;

    // Use this for initialization
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        _thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //when enemy dies drop gold destoy the enemy and give the player exp
        if (enemyCurrentHealth <= 0)
        {
            enemyPosistion = transform.position; //get position where the enemy died;
            Instantiate(enemyDrop, enemyPosistion, Quaternion.identity);
            Destroy(gameObject);
            _thePlayerStats.AddExperience(experienceToGive);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        enemyCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    public void HealEnemy(int amountToHeal)
    {
        enemyCurrentHealth += amountToHeal;
    }
}