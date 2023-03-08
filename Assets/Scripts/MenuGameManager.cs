using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGameManager : MonoBehaviour
{
	public Ball ball;
    public Paddle player1Paddle;
    public Paddle player2Paddle;

	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
	}

    public void ResetRound()
    {
		this.player1Paddle.ResetPosition();
		this.player2Paddle.ResetPosition();
		this.ball.ResetPosition();
		this.ball.Invoke("AddStartingForce", 1.5f);
	}
}