using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void GoBall()
    {
        float randX = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float randY = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        rb2d.AddForce(new Vector2(25 * randX, 7.5f * randY));
    }

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object forward along its z axis 1 unit/second.
        //transform.Translate(Vector2.right * Time.deltaTime);
    }

    void FixedUpdate()
    {

    }
}
