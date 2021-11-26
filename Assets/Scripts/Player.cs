using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Health healthScr;
    public HealthSlider slider;

    private void Start()
    {
        slider.SetMaxHealth(healthScr.health);
    }

    private void Update()
    {
        slider.SetHealth(healthScr.health);
        if (healthScr.health <= 0)
        {

        }
    }
}
