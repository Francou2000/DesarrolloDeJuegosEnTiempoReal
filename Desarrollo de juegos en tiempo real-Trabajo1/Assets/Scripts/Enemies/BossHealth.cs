using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int minHealth;


    [SerializeField] public GameObject vida;
    public HealthBar healthbar;

    public int dmg;
    float timer;
    bool setTimer;

    void Start()
    {
        
        health = maxHealth;
        vida.SetActive(true);
        healthbar.SetMaxHealth(maxHealth);
        setTimer = false;
        timer = 0;
    }

    void Update()
    {
        if (setTimer)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                setTimer = false;
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

            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AtkDeff>() && !setTimer)
        {
            setTimer = true;
            health -= dmg;
            healthbar.SetHealth(health);
        }
    }
}
