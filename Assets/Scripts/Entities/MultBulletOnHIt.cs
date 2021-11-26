using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultBulletOnHIt : MonoBehaviour {

	public GameObject bulletPrefab;
  public float y_deviation;

  void OnTriggerEnter(Collider other) {
    if(other.gameObject.CompareTag("Bullet")) {
      GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
      LinearMovement bullet_movement = bullet.GetComponent<LinearMovement>();
      Vector3 new_velocity =  new Vector3(bullet_movement.velocity.x, y_deviation, bullet_movement.velocity.z);
      bullet_movement.velocity = new_velocity;



      bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
      bullet_movement = bullet.GetComponent<LinearMovement>();
      new_velocity =  new Vector3(bullet_movement.velocity.x, -y_deviation, bullet_movement.velocity.z);
      bullet_movement.velocity = new_velocity;
    }
  }
}
