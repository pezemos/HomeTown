﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour
{
    public float moveSpeed;
    public int damageNumber;

    public Text displayNumber;

    void Start()
    {

    }

    void Update()
    {
        displayNumber.text = "" + damageNumber;
        transform.position = new Vector3(transform.position.x, 
                             transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
    }

}