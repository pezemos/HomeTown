using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{

    public string levelToLoad;
    public string exitPoint;

    private PlayerController _thePlayer;

	// Use this for initialization
	void Start ()
	{
	    _thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            _thePlayer.startPoint = exitPoint;
        }
    }
}
