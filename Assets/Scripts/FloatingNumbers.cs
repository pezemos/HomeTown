using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour
{
    public float moveSpeed;
    public int damageNumber;
	public bool criticalHit;
	public bool missedHit;


    public Text displayNumber;

    void Start()
    {

    }

    void Update()
    {
		if (criticalHit == true) {
			displayNumber.text = "Critical! " + damageNumber;
			transform.position = new Vector3 (transform.position.x, 
			transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);

		} else if (missedHit == true)
		{
			displayNumber.text = "Missed! " + damageNumber;
			transform.position = new Vector3 (transform.position.x, 
				transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
		}
		else {

			displayNumber.text = "" + damageNumber;
			transform.position = new Vector3 (transform.position.x, 
				transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
			
		}

    }

}
