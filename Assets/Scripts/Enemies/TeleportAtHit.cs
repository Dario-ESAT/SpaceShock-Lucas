using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class TeleportAtHit : EntityReaction{

  float top_height_;
  float bottom_height_;
  public float offset = 40.0f;
  private void Start() {
    PlayableArea playableArea = FindObjectOfType<PlayableArea>();
    top_height_ = playableArea.leftTopPos.y;
    bottom_height_ = playableArea.rightDownPos.y;
  }
  protected override void OnHit(Health health, EventArgs eventArgs) {
    Vector3 new_cords = new Vector3(transform.position.x,Random.Range(top_height_ - offset,bottom_height_ - -offset), transform.position.z);
    transform.position = new_cords;
  }

  protected override void OnDie(Health health, EventArgs eventArgs) {
		
		Destroy(gameObject);
	}
}
