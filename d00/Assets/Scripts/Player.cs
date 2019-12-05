using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Transform leftPaddle;
	public Transform rightPaddle;

	public static int scoreP1 = 0;
	public static int scoreP2 = 0;

	GameObject cur;
	GameObject tmp;
	int dir;
	int up;

	public GameObject pongBall;
	Rigidbody2D rb;

	void Start ()
	{
		spawnBall();
		Debug.Log("Player 1: 0 | Player 2: 0");
	}

	void Update ()
	{
		if (Input.GetKey("w"))
			leftPaddle.localPosition = new Vector2(leftPaddle.localPosition.x, leftPaddle.localPosition.y + .2f);

		if (Input.GetKey("s"))
			leftPaddle.localPosition = new Vector2(leftPaddle.localPosition.x, leftPaddle.localPosition.y - .2f);

		if (Input.GetKey(KeyCode.UpArrow))
			rightPaddle.localPosition = new Vector2(rightPaddle.localPosition.x, rightPaddle.localPosition.y + .2f);

		if (Input.GetKey(KeyCode.DownArrow))
			rightPaddle.localPosition = new Vector2(rightPaddle.localPosition.x, rightPaddle.localPosition.y - .2f);

		if (cur == null)
		{
			cur = GameObject.Find("pongBall(Clone)");
			if (cur == null)
				spawnBall();
		}
	}
	
	public void spawnBall()
	{
		tmp = Instantiate(pongBall, new Vector3(0, -.3f, 0), Quaternion.identity);
		rb = tmp.GetComponent<Rigidbody2D>();
		up = Random.Range(0, 2);
		if (up == 0)
			rb.AddForce(transform.up * 340f);
		else
			rb.AddForce(-transform.up * 340f);
		dir = Random.Range(0, 2);
		if (dir == 0)
			rb.AddForce(transform.right * 340f);
		else
			rb.AddForce(-transform.right * 340f);
	}
}
