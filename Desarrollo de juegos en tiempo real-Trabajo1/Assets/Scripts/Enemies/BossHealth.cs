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

        if (health <= 0)
        {
            GameObject cam;
            cam = GameObject.FindGameObjectWithTag("MainCamera");
            MainCamera camara;
            camara = cam.GetComponent<MainCamera>();
            camara.numenemigos += -1;

            OnDeath.Invoke();

            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AtkDeff>() && !setTimer)
        {
            anim.SetTrigger("TakeHit");
            anim.SetBool("Move",false);
            setTimer = true;
            health -= dmg;
            healthbar.SetHealth(health);
        }
    }
}
