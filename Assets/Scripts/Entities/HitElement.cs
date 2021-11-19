using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class HitElement : MonoBehaviour {

	public float hitDamage = 1.0f;
	public bool destroyOnCollide = false;

	void OnTriggerEnter(Collider other)
	{
		Health health = other.GetComponent<Health>();

		if(health != null)
			health.Hit(hitDamage);
		
		if(destroyOnCollide)
			SelfDestroy();	
	}

	void SelfDestroy()
	{
		Destroy(gameObject);
	}

}
