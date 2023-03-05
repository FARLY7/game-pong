using UnityEngine;

public class Paddle : MonoBehaviour
{
	protected Rigidbody2D _rb2d;
	public float speed;

	private void Awake()
	{
		_rb2d = GetComponent<Rigidbody2D>();
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
