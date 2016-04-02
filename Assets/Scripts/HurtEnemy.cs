using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour
{

    public int damageToGive;
    private int _currentDamage;

    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;


    private PlayerStats _thePlayerStats;

	// Use this for initialization
	void Start ()
	{
	    _thePlayerStats = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _currentDamage = damageToGive + _thePlayerStats.currentAttack;

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(_currentDamage);
            Debug.Log("Zadane obrazenia " + _currentDamage + " do " + other.gameObject.name);

            // Particle effect
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = _currentDamage;
        }
    }
}
