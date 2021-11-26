using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour {

	public GameObject bulletPrefab; 
	public float movementDistance = 10.0f;

	// Update is called once per frame
	void Update () {

		// movement

		// horizontal
		//float offsetX = 0.0f;
		//
		//if (Input.GetKey(KeyCode.LeftArrow))
		//	offsetX -= movementDistance;
		//if (Input.GetKey(KeyCode.RightArrow))
		//	offsetX += movementDistance;
		//
		//offsetX *= Time.deltaTime;

		// vertical
		float offsetY = 0.0f;

		if (Input.GetKey(KeyCode.DownArrow))
			offsetY -= movementDistance;
		if (Input.GetKey(KeyCode.UpArrow))
			offsetY += movementDistance;

		offsetY *= Time.deltaTime;
	
		transform.localPosition += new Vector3 (0.0f, offsetY, 0.0f);

		// bullet
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(bulletPrefab, transform.position + Vector3.right * 6, Quaternion.identity);
		}
	}
}
