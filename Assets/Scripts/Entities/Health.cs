using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Health : MonoBehaviour {

	public float health = 10.0f;
	public event OnDie onDie; 
	public event OnHit onHit; 
	public delegate void OnHit(Health health, EventArgs eventArgs);
	public delegate void OnDie(Health health, EventArgs eventArgs);

    public void Hit(float damage)
	{
		health -= damage;

		if(health <= 0)
        {
            if (onDie != null)
                onDie(this, null);
        }
		else
        {
            if(onHit != null)
			    onHit(this, null);
        }
	}
}
