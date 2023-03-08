using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
	public Rigidbody2D ball;
	private SpriteRenderer spriteRenderer;
	public float lerpSpeed = 1f;

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

			//if (ball.transform.position.y > transform.position.y + 0.4) {
			//	if (this._rb2d.velocity.y < 0) this._rb2d.velocity = Vector2.zero;
			//	this._rb2d.velocity = Vector2.Lerp(this._rb2d.velocity, Vector2.up * speed, lerpSpeed * Time.deltaTime);
			//} else if (ball.transform.position.y < transform.position.y - 0.4) {
			//	if (this._rb2d.velocity.y > 0) this._rb2d.velocity = Vector2.zero;
			//	this._rb2d.velocity = Vector2.Lerp(this._rb2d.velocity, Vector2.down * speed, lerpSpeed * Time.deltaTime);
			//} else {
			//	this._rb2d.velocity = Vector2.Lerp(this._rb2d.velocity, Vector2.zero * speed, lerpSpeed * Time.deltaTime);
			//}

			/* Ball is moving towards the paddle,
				* move towards the ball */
			if (this.ball.position.y > this.transform.position.y + 0.5) {
				this._rb2d.AddForce(Vector2.up * this.speed);
			} else if (this.ball.position.y < this.transform.position.y - 0.5) {
				this._rb2d.AddForce(Vector2.down * this.speed);
			}

		} else {
			/* Ball is moving away from the paddle,
				* move towards center of screen */
			if (this.transform.position.y > 1f) {
				this._rb2d.AddForce(Vector2.down * this.speed);
			} else if (this.transform.position.y < -1f) {
				this._rb2d.AddForce(Vector2.up * this.speed);
			}
		}
	}
}
