using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour {

	public Vector3 velocity = Vector3.right;


	// Update is called once per frame
	void Update () {
	
		transform.localPosition += velocity * Time.deltaTime;
	}
}
