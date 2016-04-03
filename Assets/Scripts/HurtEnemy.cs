using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour
{

    public int damageToGive;
    private int _currentDamage;

    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;

	public int minRanDam  = -3;
	public int maxRanDam = +3;
	private int randomDamage;

	private bool iDidCrit;
	private bool iDidMiss;

	public int critChance;
	public int missChance;
	public int critBonusDamage;

	private int critmiss;



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
			critmiss = Random.Range (1, 100);
			randomDamage = Random.Range (minRanDam, maxRanDam);

			if (critmiss < missChance) {
				//miss 
				iDidMiss = true;
				_currentDamage = 0;
				Debug.Log ("Zadane obrazenia Missed!");

			}
			 else if (critmiss > critChance) {
				//critical 
			
				iDidCrit = true;
				_currentDamage = (damageToGive + _thePlayerStats.currentAttack + randomDamage) + critBonusDamage;
				other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (_currentDamage);
				Debug.Log ("Zadane obrazenia Critical!" + _currentDamage + " do " + other.gameObject.name);

			}
			 else {
				//normal attack

				_currentDamage = (damageToGive + _thePlayerStats.currentAttack + randomDamage);
				other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (_currentDamage);
				Debug.Log ("Zadane obrazenia " + _currentDamage + " do " + other.gameObject.name);

			}
			// Particle effect

		

			if (iDidCrit == true) {
				var clone = (GameObject)Instantiate (damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
				Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);
				clone.GetComponent<FloatingNumbers> ().criticalHit = true;
				clone.GetComponent<FloatingNumbers> ().damageNumber = _currentDamage;
			}
			else if (iDidMiss == true) {
				var clone = (GameObject)Instantiate (damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
				Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);
				clone.GetComponent<FloatingNumbers> ().missedHit = true;
				clone.GetComponent<FloatingNumbers> ().damageNumber = _currentDamage;
			} else {
				var clone = (GameObject)Instantiate (damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
				Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);
				clone.GetComponent<FloatingNumbers> ().damageNumber = _currentDamage;
			}
			iDidCrit = false;
			iDidMiss = false;
		}


    }
}
