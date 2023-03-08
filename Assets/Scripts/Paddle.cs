using UnityEngine;

public class Paddle : MonoBehaviour
{
	protected Rigidbody2D _rb2d;
	public float speed;

	public float yBounceScale;

	private void Awake()
	{
		_rb2d = GetComponent<Rigidbody2D>();
	}

	//private void OnTriggerEnter2D(Collider2D collision)
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Ball ball = collision.gameObject.GetComponent<Ball>();

		if (ball != null) {
			/* Get normal of surface it collided with */
			//float coly = collision.GetContact(0).point.y;

			float coly = collision.transform.position.y;
			float recty = this.transform.position.y;

			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

			float halfHeight = spriteRenderer.bounds.size.y / 2;

			float col = recty - coly;
			float ratio = (col / halfHeight);

			UnityEngine.Debug.Log($"Collision ({coly}), Rectangle ({recty}), Col ({col}), Ratio ({ratio})");

			Vector2 normal = collision.GetContact(0).normal * -1;
			UnityEngine.Debug.Log($"1. Normal ({normal})");

			Vector2 vel = ball._rb2d.velocity;

			/* Clamp ratio at 45*, 90* is too much.?
			 * Try with ontrigger, with collision there is a weird boomerang
			 **/

			if (normal.x == 1) {
				/* Player 1 */
				normal = Quaternion.AngleAxis(65 * ratio * -1, Vector3.forward) * normal;
				//ball.transform.rotation = Quaternion.AngleAxis(90 * ratio * -1, Vector3.forward);
				//ball._rb2d.velocity = ball._rb2d.velocity * -1;

				//vel.y = ratio * -4;

			} else if (normal.x == -1) {
				/* Player 2 */
				normal = Quaternion.AngleAxis(65 * ratio, Vector3.forward) * normal;
				//ball.transform.rotation = Quaternion.AngleAxis(90 * ratio, Vector3.forward);
				//normal = Quaternion.AngleAxis(90 * ratio * -1, Vector3.forward) * normal;

				//vel.y = ratio * -4;
			}
			else {
				return;
			}
			//UnityEngine.Debug.Log($"2. Normal ({normal})");

			//normal = Vector2.Reflect(ball._rb2d.velocity, normal);

			normal.x = vel.x;
			normal.y = normal.y * 4;
			ball._rb2d.velocity = normal;

			//normal.x = normal.x * Mathf.Abs(ball._rb2d.velocity.x);
			//normal.y = normal.y * Mathf.Abs(ball._rb2d.velocity.y);

			//ball._rb2d.velocity = vel;
			UnityEngine.Debug.Log($"3. Normal ({normal})");

			//ball.AddForce(normal * 1, ForceMode.VelocityChange);

		}
	}

	public void ResetPosition()
	{
		//_rb2d.position.y = Vector2.zero;
		//Vector2 position = this.transform.position;
		//this.transform.position = position;

		Vector2 position = _rb2d.position;
		position.y = 0;
		_rb2d.position = position;
		_rb2d.velocity = Vector2.zero;
	}
}

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	Ball ball = collision.gameObject.GetComponent<Ball>();

	//	if (ball != null) {
	//		/* Get normal of surface it collided with */
	//		//float coly = collision.GetContacts(0).point.y;

	//		float coly = ball.transform.position.y;

	//		float recty = this.transform.position.y;

	//		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

	//		float halfHeight = spriteRenderer.bounds.size.y / 2;

	//		float col = recty - coly;
	//		float ratio = (col / halfHeight);


	//		UnityEngine.Debug.Log($"Collision ({coly}), Rectangle ({recty}), Col ({col}), Ratio ({ratio})");

	//		//Vector2 normal = collision.GetContact(0).normal * -1;
	//		//UnityEngine.Debug.Log($"1. Normal ({normal})");

			
	//		Vector2 vel = ball._rb2d.velocity;
	//		UnityEngine.Debug.Log($"1. Vel ({vel})");
	//		vel.x = vel.x * -1;
	//		UnityEngine.Debug.Log($"2. Vel ({vel})");

	//		//if (normal.x > 0) {
	//		//	/* Player 1 */
	//		//	normal = Quaternion.AngleAxis(90 * ratio * -1, Vector3.forward) * normal;
	//		//	//ball.transform.rotation = Quaternion.AngleAxis(90 * ratio * -1, Vector3.forward);
	//		//	//ball._rb2d.velocity = ball._rb2d.velocity * -1;

	//		//	//vel.y = ratio * -4;

	//		//} else {
	//		//	/* Player 2 */
	//		//	normal = Quaternion.AngleAxis(90 * ratio, Vector3.forward) * normal;
	//		//	//ball.transform.rotation = Quaternion.AngleAxis(90 * ratio, Vector3.forward);
	//		//	//normal = Quaternion.AngleAxis(90 * ratio * -1, Vector3.forward) * normal;

	//		//	//vel.y = ratio * -4;
	//		//}

	//		//vel.y = ratio * -4;

	//		//UnityEngine.Debug.Log($"2. Normal ({normal})");

	//		//normal = Vector2.Reflect(ball._rb2d.velocity, normal);

	//		//ball._rb2d.velocity = normal * 5;

	//		//normal.x = normal.x * Mathf.Abs(ball._rb2d.velocity.x);
	//		//normal.y = normal.y * Mathf.Abs(ball._rb2d.velocity.y);


	//		ball._rb2d.velocity = vel;
	//		//UnityEngine.Debug.Log($"3. Normal ({normal})");

	//		//ball.AddForce(normal * 1);

	//	}
	//}

	//public void ResetPosition()
	//{
	//	//_rb2d.position.y = Vector2.zero;
	//	//Vector2 position = this.transform.position;
	//	//this.transform.position = position;

	//	Vector2 position = _rb2d.position;
	//	position.y = 0;
	//	_rb2d.position = position;
	//	_rb2d.velocity = Vector2.zero;
	//}
//}
