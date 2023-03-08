using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
	public Rigidbody2D ball;


	private SpriteRenderer spriteRenderer;

	private float nextMove = 0.0f;
	private float moveRate = 0.01f;

	private void Awake()
	{
		this._rb2d = this.GetComponent<Rigidbody2D>();
		this.spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void FixedUpdate()
	{
		// calculate the direction from the ball to the paddle using the position of each object
		Vector2 ballDirection = transform.position - ball.transform.position;
		// calculate the relative velocity between the two objects
		Vector2 relativeVelocity = ball.velocity - this._rb2d.velocity;
		// calculate the dot product of the two
		float dotProduct = Vector2.Dot(relativeVelocity, ballDirection.normalized);

		if (dotProduct > 0) {

			//if (Time.time > nextMove) {

				//float halfHeight = this.spriteRenderer.bounds.size.y / 2;

				//if ((this.ball.position.y <= this.transform.position.y + halfHeight) &&
				//	(this.ball.position.y >= this.transform.position.y - halfHeight))
				//{
				if (this.ball.position.y > this.transform.position.y) {
					this._rb2d.AddForce(Vector2.up * this.speed);
				} else if (this.ball.position.y < this.transform.position.y) {
					this._rb2d.AddForce(Vector2.down * this.speed);
				}

				//nextMove = Time.time + moveRate;
				//}
			//}

			/* Ball is moving towards the paddle,
			 * move towards the ball */
			//if (this.ball.position.y > this.transform.position.y) {
			//	this._rb2d.AddForce(Vector2.up * this.speed);
			//} else if (this.ball.position.y < this.transform.position.y) {
			//	this._rb2d.AddForce(Vector2.down * this.speed);
			//}

		} else {
			/* Ball is moving away from the paddle,
			 * move towards center of screen */
			if (this.transform.position.y > 0.0f) {
				this._rb2d.AddForce(Vector2.down * this.speed);
			} else if (this.transform.position.y < 0.0f) {
				this._rb2d.AddForce(Vector2.up * this.speed);
			}
		}
	}
}
