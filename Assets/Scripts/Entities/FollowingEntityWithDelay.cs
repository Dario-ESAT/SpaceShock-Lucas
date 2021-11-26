using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEntityWithDelay : MonoBehaviour {
    
  public GameObject following;

  public int follow_delay = 50;

  List<float> delay_list;
  void Start() {
    for (int i = 0; i < follow_delay; i++) {
      delay_list.Add(following.transform.position.y);
    }
  }

  // Update is called once per frame
  void FixedUpdate() {
    for (int i = 0; i < follow_delay; i++) {
      delay_list[i] = delay_list[i + 1];
    }
    delay_list[follow_delay - 1] = following.transform.position.y;
    transform.position = new Vector3(transform.position.x,delay_list[0],0);
  }
}
