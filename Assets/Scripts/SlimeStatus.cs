using UnityEngine;
using System.Collections;

public class SlimeStatus : MonoBehaviour
{

    public float minDistance; // min distance to get aggressive
    public bool foreverAggressive = false; // if activated, the slime will not be able to become passive after being aggressive
    private float distance; // the current distance between the slime and the player
    private GameObject player; // the player gameobject
    public bool isAggressive; // if the slime is angry

    void Start()
    {
        player = GameObject.Find("Player"); // set the player gameobject to the player variable
        isAggressive = false; // the slime starts passive
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position); // gets the distance between the slime and the player

        if (distance < minDistance) // if the current distance is lesser than the mininum distance to become aggressive...
        {
            isAggressive = true; // then become aggressive
        }
        else // if the current distance is greater than the minimum distance...
        {
            if (foreverAggressive == false) // if it can become passive again...
            {
                isAggressive = false; // then become passive
            }
        }
    }
}