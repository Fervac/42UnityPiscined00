using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

	int speed;
	public int cubeStyle;

	public Transform[] other;

	void Start ()
	{
		speed = Random.Range(1, 3);
		DestroyObjectDelayed();
	}

	void DestroyObjectDelayed()
    {
        Destroy(gameObject, 4);
    }

	void Update ()
	{
		Vector3 pos = transform.position;
		pos.y = pos.y - 1 * Time.deltaTime * speed;

		transform.position = Vector3.Lerp(transform.position, pos, 1f);

		if (Input.GetKeyDown("a") && cubeStyle == 0)
		{
			float dist = Vector3.Distance(other[0].position, transform.position);
            print("Precision: " + dist);
		}

		if (Input.GetKeyDown("s") && cubeStyle == 1)
		{
			float dist = Vector3.Distance(other[1].position, transform.position);
            print("Precision: " + dist);
		}

		if (Input.GetKeyDown("d") && cubeStyle == 2)
		{
			float dist = Vector3.Distance(other[2].position, transform.position);
            print("Precision: " + dist);
		}
	}
}
