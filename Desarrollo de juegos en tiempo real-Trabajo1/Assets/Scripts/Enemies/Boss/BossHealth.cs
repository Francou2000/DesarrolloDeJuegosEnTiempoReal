using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class BossHealth : MonoBehaviour, IDamageable
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
    public UnityEvent SecondPhase = new UnityEvent();

    public UnityEvent NoLife = new UnityEvent();

    public PlayableDirector timelineDirector;
    public GameObject player;

    [SerializeField] AudioClip hitClip;
    AudioSource myAudioSource;

    void Start()
    {
        anim= GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        health = maxHealth;
        vida.SetActive(true);
        healthbar.SetMaxHealth(maxHealth);
        setTimer = false;
        timer = 0;
        VolumeController.Instance.volumeUpdate.AddListener(SetSFXVolume);
        SetSFXVolume();
    }

    private void SetSFXVolume()
    {
        myAudioSource.volume = VolumeController.Instance.SFXVolume;
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

    public void GetDamage(int damage)
    {
        anim.SetTrigger("TakeHit");
        setTimer = true;
        health -= damage;
        myAudioSource.clip = hitClip;
        myAudioSource.Play();
        if(health == 100)
        {
            SpecialAttack.Invoke();
        }
        if (health == 40)
        {
            SpecialAttack.Invoke();
        }
        if (health == health / 2)
        {
            SecondPhase.Invoke();
        }
        if (health <= 0)
        {
            GetKilled();
        }
        healthbar.SetHealth(health);
    }

    public void GetKilled()
    {
        StartCoroutine(DeathCourutine());
    }

    public IEnumerator DeathCourutine()
    {
        player.GetComponent<PlayerMovement>().enabled = false;

        NDoulAttack deactivateNDoul = GetComponent<NDoulAttack>();
        if (deactivateNDoul != null)
        {
            deactivateNDoul.enabled = false;
        }

        BossAttacks deactivateDio = GetComponent<BossAttacks>();
        if (deactivateDio != null)
        {
            deactivateDio.enabled = false;
        }

        SeanAttacks deactivateSean = GetComponent<SeanAttacks>();
        if (deactivateSean != null)
        {
            deactivateSean.enabled = false;
        }
        
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
