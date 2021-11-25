using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float rotation;
    public float length;

    void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x*length, transform.localScale.y, transform.localScale.z);
        transform.RotateAround(transform.position, transform.right, rotation);
    }
}
