using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public float moveSpeed;

    private bool upKeyPressed = false;
    private bool downKeyPressed = false;
    
    // Update is called once per frame
    void Update()
    {
        upKeyPressed = Input.GetKey(upKey);
        downKeyPressed = Input.GetKey(downKey);
    }

    void FixedUpdate()
    {
        if(upKeyPressed)
        {
            gameObject.transform.Translate(0, moveSpeed, 0);
        }
        if (downKeyPressed)
        {
            gameObject.transform.Translate(0, -moveSpeed, 0);
        }
    }
}
