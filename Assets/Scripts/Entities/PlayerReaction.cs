using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReaction : EntityReaction {

	public event OnPlayerDie onPlayerDie; 
	public delegate void OnPlayerDie(EventArgs eventArgs);

	protected override void OnHit(Health health, EventArgs eventArgs)
	{
		
	}

	protected override void OnDie(Health health, EventArgs eventArgs)
	{
		// TODO: do something cool here
		onPlayerDie(null);
		Debug.Log("Game Over");
	}
}
