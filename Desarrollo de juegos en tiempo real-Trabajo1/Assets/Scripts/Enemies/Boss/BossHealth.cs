using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

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
    public UnityEvent SpecialAttack = new UnityEvent();

    public UnityEvent NoLife = new UnityEvent();

    public PlayableDirector timelineDirector;
    public GameObject player;


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
        if (collision.GetComponent<PlayerActions>() && !setTimer)
        {
           
            anim.SetTrigger("TakeHit");
            setTimer = true;
            health -= dmg;
            healthbar.SetHealth(health);
            if(health == 100)
            {
                SpecialAttack.Invoke();
            }
            if (health == 40)
            {
                SpecialAttack.Invoke();
            }
            if (health <= 0)
            {
                StartCoroutine(DeathCourutine());
            }

        }
    }

    public IEnumerator DeathCourutine()
    {
        player.GetComponent<PlayerMovement>().enabled = false;

        GetComponent<NDoulAttack>().enabled = false;

        GetComponent<SpriteRenderer>().enabled = false;
        NoLife.Invoke();

        if (timelineDirector != null)
        {
            timelineDirector.Play();
        }

        yield return new WaitForSeconds((float)timelineDirector.duration);

        OnDeath.Invoke();

        Destroy(this.gameObject);

        yield return null;
    }

}
