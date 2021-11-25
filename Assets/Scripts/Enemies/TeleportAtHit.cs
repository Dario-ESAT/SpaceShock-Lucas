using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAtHit : EntityReaction{
protected override void OnHit(Health health, EventArgs eventArgs) {

}

protected override void OnDie(Health health, EventArgs eventArgs) {
		
		Destroy(gameObject);
	}
}
