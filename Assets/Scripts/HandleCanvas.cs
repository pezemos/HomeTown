using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HandleCanvas : MonoBehaviour
{

    private CanvasScaler _scaler;

	// Use this for initialization
	void Start ()
	{
	    _scaler = GetComponent<CanvasScaler>();
	    _scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
	}

}
