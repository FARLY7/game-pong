using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
	public Rigidbody2D ball;

	private void FixedUpdate()
	{
		if (this.ball.velocity.x > 0) {
			/* Ball is moving towards the computer paddle,
			 * move towards the ball */
			if (this.ball.position.y > this.transform.position.y) {
				_rb2d.AddForce(Vector2.up * this.speed);
			} else if (this.ball.position.y < this.transform.position.y) {
				_rb2d.AddForce(Vector2.down * this.speed);
			}
		}
		else
		{
			/* Ball is moving away from the computer paddle,
			 * move towards center of screen */
			if(this.transform.position.y > 0.0f) {
				_rb2d.AddForce(Vector2.down * this.speed);
			}
			else if(this.transform.position.y < 0.0f) {
				_rb2d.AddForce(Vector2.up * this.speed);
			}
		}
	}
}
