using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sliderHealth;
    public GameObject target;

    private bool isTargetActive;

    private void Start()
    {
        isTargetActive = false;
        sliderHealth.gameObject.SetActive(true);
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

        // Verificar si el objetivo está activo en la escena
        if (target != null && target.activeSelf != isTargetActive)
        {
            isTargetActive = target.activeSelf;
            sliderHealth.gameObject.SetActive(isTargetActive);
        }
    }
}



