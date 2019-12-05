using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
	GameObject pongBall;

	void Start ()
	{
		pongBall = this.gameObject;
	}

	void OnTriggerEnter2D(Collider2D col)
    {
		if (col.name == "out1")
			Player.scoreP2 += 1;
		if (col.name == "out2")
			Player.scoreP1 += 1;

		Debug.Log("Player 1: " + Player.scoreP1 + " | Player 2: " + Player.scoreP2);

		Destroy(pongBall);
    }
}
