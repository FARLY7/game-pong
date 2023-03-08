using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
	public KeyCode upKey;
	public KeyCode downKey;

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
		if (upKeyPressed) {
			_rb2d.AddForce(Vector2.up * speed);
		}
		if (downKeyPressed) {
			_rb2d.AddForce(Vector2.down * speed);
		}
	}
}
