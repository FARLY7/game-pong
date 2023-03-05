using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Ball ball;
    public Paddle player1Paddle;
    public Paddle player2Paddle;

    public TMPro.TMP_Text player1ScoreText;
	public TMPro.TMP_Text player2ScoreText;

	private int _player1Score = 0;
	private int _player2Score = 0;

	void Start()
    {
        print("GAME START");
    }

    // Update is called once per frame
    void Update()
    {
        if(_player1Score == 10)
        {
            print("Player 1 wins!");
        }
        else if(_player2Score == 10)
        {
            print("Player 2 wins!");
        }
    }

    public void Player1Score()
    {
		_player1Score++;
        this.player1ScoreText.SetText(_player1Score.ToString());
        ResetRound();
	}

    public void Player2Score()
    {
		_player2Score++;
		this.player2ScoreText.SetText(_player2Score.ToString());
        ResetRound();
	}

    public void ResetRound()
    {
		this.player1Paddle.ResetPosition();
		this.player2Paddle.ResetPosition();
		this.ball.ResetPosition();
		this.ball.Invoke("AddStartingForce", 1.5f);
	}

}


