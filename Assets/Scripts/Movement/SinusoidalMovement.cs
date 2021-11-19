using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMovement : MonoBehaviour {

	public Vector3 direction = Vector3.up;
	public float range = 2.0f;
	public float frequencyFactor = 10.0f;
	public bool randomFrequencyStart = false;

	private float m_randomFrequencyPush = 0.0f;

	private Vector3 m_previousOffset = Vector3.zero;

	void Start()
	{
		if (randomFrequencyStart)
			m_randomFrequencyPush = Random.Range (0.0f, Mathf.PI);
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 currentOffset = direction * (Mathf.Sin (Time.time * frequencyFactor + m_randomFrequencyPush) * range);
		transform.localPosition += (currentOffset - m_previousOffset);
		m_previousOffset = currentOffset;
	}
}
