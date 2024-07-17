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
    private Animator myAnimator;

    [SerializeField] public GameObject healthBarGO;
    public HealthBar healthBar;

    public int damage;

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
        myAnimator= GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        health = maxHealth;
        healthBarGO.SetActive(true);
        healthBar.SetMaxHealth(maxHealth);
        VolumeController.Instance.volumeUpdate.AddListener(SetSFXVolume);
        SetSFXVolume();
    }

    private void SetSFXVolume()
    {
        myAudioSource.volume = VolumeController.Instance.SFXVolume;
    }



    public void GetDamage(int damage)
    {
        myAnimator.SetTrigger("TakeHit");
        health -= damage;
        myAudioSource.clip = hitClip;
        myAudioSource.Play();
        if(health == 100)               //Roadroller
        {
            SpecialAttack.Invoke();
        }
        if (health == 40)               //Roadroller
        {
            SpecialAttack.Invoke();
        }
        if (health <= maxHealth / 2)    //Sean 2°
        {
            SecondPhase.Invoke();
        }
        if (health <= 0)
        {
            GetKilled();
        }
        healthBar.SetHealth(health);
    }

    public void GetKilled()
    {
        StartCoroutine(DeathCourutine());
    }

    public IEnumerator DeathCourutine()
    {
        player.GetComponent<PlayerMovement>().CanMove = false;

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
