using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
	Rigidbody2D rb;
	public Text scoreText;

	int score = 0;

	float force = 65f;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		InvokeRepeating("increase", 2.0f, 2.0f);
	}

	void increase()
	{
		score += 5;
	}

	void Update ()
	{
		if (Time.timeScale > 0)
			transform.localPosition = new Vector3(transform.localPosition.x + .1f, transform.localPosition.y, transform.localPosition.z);

		scoreText.text = score.ToString();

		if (Input.GetKeyDown("space"))
		{
			flap();
		}
	}

	void flap()
	{
		rb.velocity = Vector3.zero;
    	rb.angularVelocity = 0f;

		rb.AddForce(transform.up * force);
	}

	void OnCollisionEnter2D(Collision2D col)
    {
        Time.timeScale = 0;
    }
}
