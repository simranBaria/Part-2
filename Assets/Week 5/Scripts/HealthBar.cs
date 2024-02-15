using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetHealth(float newHealth)
    {
        slider.value = newHealth;

    }

    public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }
}
