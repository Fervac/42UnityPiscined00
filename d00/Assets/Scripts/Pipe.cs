using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
	public Transform background1;
	public Transform background2;

	public Transform ground1;
	public Transform ground2;

	public Transform holder;

	public GameObject pipe;

	GameObject tmp;

	private bool whichone = true;
	private bool whichone2 = true;

	public Transform cam;

	private float currentx = 4;
	private float currentx2 = 8;

	void Start ()
	{
		InvokeRepeating("spawn", 1.0f, 2.0f);
    }

    void spawn()
    {
        tmp = Instantiate(pipe, new Vector3(currentx + 2, Random.Range(-1, 2), 0), Quaternion.identity);

		Object.Destroy(tmp, 5f);
    }

	void Update ()
	{
		if (currentx < cam.position.x)
		{
			if (whichone)
				background1.localPosition = new Vector3(background1.localPosition.x + 8, 0, 0);
			else
				background2.localPosition = new Vector3(background2.localPosition.x + 8, 0, 0);

			currentx += 4;

			whichone = !whichone;
		}

		if (currentx2 < cam.position.x)
		{
			if (whichone2)
				ground1.localPosition = new Vector3(ground1.localPosition.x + 16, -5, 0);
			else
				ground2.localPosition = new Vector3(ground2.localPosition.x + 16, -5, 0);

			currentx2 += 8;

			whichone2 = !whichone2;
		}

		if (currentx > cam.position.x + 4)
		{
			if (whichone)
				background2.localPosition = new Vector3(background2.localPosition.x - 8, 0, 0);
			else
				background1.localPosition = new Vector3(background1.localPosition.x - 8, 0, 0);

			currentx -= 4;

			whichone = !whichone;
		}

		if (currentx2 > cam.position.x + 8)
		{
			if (whichone2)
				ground2.localPosition = new Vector3(ground2.localPosition.x - 16, -5, 0);
			else
				ground1.localPosition = new Vector3(ground1.localPosition.x - 16, -5, 0);

			currentx2 -= 8;

			whichone2 = !whichone2;
		}

		if (Time.timeScale > 0)
			cam.localPosition = new Vector3(cam.localPosition.x + .1f, cam.localPosition.y, cam.localPosition.z);
	}
}
