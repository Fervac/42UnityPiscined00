using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
	Vector3 range;
	public GameObject ball;
	Transform ballT;
	Vector3 ballV;
	public GameObject hole;
	float speed;
	Rigidbody2D rb;

	void Start ()
	{
		ballT = ball.GetComponent<Transform>();
		ballV = ballT.position;
		range = ballV;
		rb = ball.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		if (Input.GetKey("space"))
		{
			if (ball.transform.position.y < hole.transform.position.y)
				range.y -= .5f;
			else
				range.y += .5f;
			transform.position = range;
		}
		else
		{
			speed = rb.velocity.magnitude;
			if(speed < 0.4)
			{
				ballV = ballT.position;
	            range.y = ballV.y + .3f;
				transform.position = range;
			}
		}
	}
}
