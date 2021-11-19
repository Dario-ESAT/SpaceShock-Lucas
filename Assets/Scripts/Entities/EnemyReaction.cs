using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReaction : EntityReaction {

	protected override void OnHit(Health health, EventArgs eventArgs)
	{
		// TODO: do something cool here
	}

	protected override void OnDie(Health health, EventArgs eventArgs)
	{
		// TODO: do something cool here
		Destroy(gameObject);
	}
}
