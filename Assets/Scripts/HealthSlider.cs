using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float value)
    {
        slider.maxValue = value;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
