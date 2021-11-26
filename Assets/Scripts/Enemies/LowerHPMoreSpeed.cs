using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerHPMoreSpeed : EntityReaction{

  LinearMovement movement_;
  float starting_health;
  float starting_velocity;
  void Start() {
      movement_ = GetComponent<LinearMovement>();
      starting_health = c_health.health;
      starting_velocity = movement_.velocity.x;
  }
  protected override void OnHit(Health health, EventArgs eventArgs) {
    movement_.velocity.x -= starting_velocity - starting_velocity * (c_health.health/starting_health);
  }

  protected override void OnDie(Health health, EventArgs eventArgs) {
      Destroy(gameObject);
  }
}
