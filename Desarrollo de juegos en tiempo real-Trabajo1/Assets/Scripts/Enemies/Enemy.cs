using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int dmg;
    float timer;
    bool SetTimer;

    private Animator anim;
    

    void Start()
    {
        SetTimer = false;
        timer = 0;
        
        anim = GetComponent<Animator>();
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
            //camara.numenemigos += -1;

            //Debug.Log("Enemigo muerto");

            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AtkDeff>() && SetTimer == false)
        {
            SetTimer = true;
            health -=  dmg;

            anim.SetTrigger("TakeHit");
            anim.SetBool("Move", false);
        }
    }
}
