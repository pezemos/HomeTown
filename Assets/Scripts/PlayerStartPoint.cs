using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour
{

    private PlayerController _thePlayer;
    private CameraController _theCamera;

    public Vector2 startDirection;

    public string pointName;

	// Use this for initialization
	void Start ()
	{   
	    _thePlayer = FindObjectOfType<PlayerController>();

	    if (_thePlayer.startPoint == pointName)
	    {
            _thePlayer.transform.position = transform.position;
            _thePlayer.lastMove = startDirection;

            _theCamera = FindObjectOfType<CameraController>();
            _theCamera.transform.position = new Vector3(transform.position.x, transform.position.y,
                                            _theCamera.transform.position.z);
        }
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
