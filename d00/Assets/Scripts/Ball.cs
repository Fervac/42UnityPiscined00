using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	float power;
	float speed;

	Vector3 clubV;
	public GameObject wall;
	public GameObject club;
	public GameObject hole;
	Rigidbody2D rb;

	int score = -15;

	SpriteRenderer SR;

	void Start ()
	{
		power = 0f;
		SR = club.GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		if (Input.GetKey("space"))
		{
			power += .1f;
		}

		if (Input.GetKeyUp("space"))
        {
			score += 5;
			Debug.Log("Score: " + score);
			if (transform.position.y < hole.transform.position.y)
				rb.AddForce(transform.up * power * Time.deltaTime);
			else
				rb.AddForce(-transform.up * power * Time.deltaTime);
			clubV = transform.position;
			clubV.x -= .2f;
			club.transform.position = clubV;
			power = 0f;
		}

		speed = rb.velocity.magnitude;
		if(speed < 0.5)
		{
			if (transform.position.y < hole.transform.position.y)
				SR.flipY = false;
			else
				SR.flipY = true;
			float dist = Vector3.Distance(hole.transform.position, transform.position);
			if (dist < .7f)
				Debug.Log("Victory!");
		}
	}
}
