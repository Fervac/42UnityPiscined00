using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
	int style;
	GameObject tmp;

	public GameObject cube;
	public Transform[] array;
	public Sprite[] spriteList;

	void Start()
    {
        InvokeRepeating("spawnCube", 1.0f, Random.Range(0f, 2.0f));
    }

	void spawnCube()
	{
		style = Random.Range(0, 3);

		tmp = GameObject.Instantiate(cube, array[style]);

		Cube SN = tmp.GetComponent<Cube>();
		SN.cubeStyle = style;
		tmp.GetComponent<SpriteRenderer>().sprite = spriteList[style];
		tmp.transform.localScale = new Vector3(.1f, .1f, .1f);
	}
}
