using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
	int size = 50;
	int maxsize = 100;
	int minsize = 10;
	int blow = 50;
	int opti;

	void Start()
    {
        InvokeRepeating("decrease", 1.0f, .5f);
    }

	void decrease()
	{
		size -= 10;
		blow += 10;
	}

	void Update ()
	{
		float timeNow = Time.realtimeSinceStartup;
		if (Input.GetKeyDown("space"))
		{
			size += 10;
			blow -= 10;
		}

		if (size > maxsize)
		{
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(timeNow) + "s");
			GameObject.Destroy(this);
		}

		if (size < minsize)
		{
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(timeNow) + "s");
			GameObject.Destroy(this);
		}

		opti = size / 3;
		transform.localScale = new Vector3(opti, opti, opti);
	}
}
