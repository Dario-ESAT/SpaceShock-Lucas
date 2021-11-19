using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityReaction : MonoBehaviour {

	public Health c_health;

	// Use this for initialization
	void Start ()
	{
		c_health.onHit += new Health.OnHit(OnHit);
		c_health.onDie += new Health.OnDie(OnDie);
	}


	protected abstract void OnHit(Health health, EventArgs eventArgs);
	protected abstract void OnDie(Health health, EventArgs eventArgs);
}
