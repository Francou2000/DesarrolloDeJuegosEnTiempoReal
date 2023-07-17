using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int minHealth;
    private Animator anim;

    [SerializeField] public GameObject vida;
    public HealthBar healthbar;

    public int dmg;
    float timer;
    bool setTimer;

    public UnityEvent OnDeath = new UnityEvent(); 

    void Start()
    {
        anim= GetComponent<Animator>();
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

      
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AtkDeff>() && !setTimer)
        {
           
            anim.SetTrigger("TakeHit");
            setTimer = true;
            health -= dmg;
            healthbar.SetHealth(health);
            if (health <= 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
