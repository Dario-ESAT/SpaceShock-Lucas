using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerHPMoreSpeed : EntityReaction{

  LinearMovement movement_;
  void Start() {
      
  }
  protected override void OnHit(Health health, EventArgs eventArgs) {

    // c_health;
  }

  protected override void OnDie(Health health, EventArgs eventArgs) {
      
      Destroy(gameObject);
  }
}
