using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float dmg;
    float timer;
    bool SetTimer;

    void Start()
    {
        SetTimer = false;
        timer = 0;
        
    }

    void Update()
    {
        if (SetTimer)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                SetTimer = false;
                timer = 0;
            }
        }

        if (health <= 0)
        {
            GameObject cam;
            cam = GameObject.FindGameObjectWithTag("MainCamera");
            MainCamera camara;
            camara = cam.GetComponent<MainCamera>();
            camara.numenemigos += -1;

            //Debug.Log("Enemigo muerto");

            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AtkDeff>() && SetTimer == false)
        {
            SetTimer = true;
            health = health - dmg;
        }
    }
}
