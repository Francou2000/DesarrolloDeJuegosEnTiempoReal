using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sliderHealth;

    

    private void Start()
    {

    }

    public void SetMaxHealth(int health)
    {
        sliderHealth.maxValue = health;
        sliderHealth.value = health;
    }

    public void SetHealth(int health)
    {
        sliderHealth.value = health;
    }

    public void Update()
    {
        if (sliderHealth.value == 0)
        {
            Destroy(gameObject);
        }

        
    }
}



