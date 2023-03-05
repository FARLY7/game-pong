using UnityEngine;

public class BouncySurface : MonoBehaviour
{
	public float bounceStrength;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Ball ball = collision.gameObject.GetComponent<Ball>();

		if(ball != null)
		{
			/* Get normal of surface it collided with */
			Vector2 normal = collision.GetContact(0).normal;

			ball.AddForce(-normal * this.bounceStrength);
		}
	}
}
