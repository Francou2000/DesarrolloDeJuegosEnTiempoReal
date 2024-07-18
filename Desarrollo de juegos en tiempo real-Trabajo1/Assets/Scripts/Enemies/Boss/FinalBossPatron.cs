using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinalBossPatron : MonoBehaviour
{
    public float setSpeed;
    float currentSpeed;
    float timer; //attack cooldown
    [SerializeField] float attackCooldown = 1.5f;
    float timer2; //attack collider duration
    [SerializeField] float hitBoxDuration = 0.5f;
    public float stopDist;

    public GameObject target;
    public GameObject bullet;
    public GameObject firePoint;

    private float targetDist;

    private Animator myAnimator;
    BossAttack myBossAttack;

    public UnityEvent Onhit = new UnityEvent();


    bool attackType;  //true = melee, false = range
    int counter;
    [SerializeField] int maxAttackCounter = 4;

    [SerializeField] AudioClip attackClip;
    AudioSource myAudioSource;


    void Start()
    {
        timer = 0;
        timer2 = 0;
        currentSpeed = setSpeed;
        myBossAttack = GetComponentInChildren<BossAttack>();
        myAnimator = GetComponent<Animator>();
        attackType = true;
        counter = 0;
        myAudioSource = GetComponent<AudioSource>();
        GetComponent<BossHealth>().NoLife.AddListener(Deactive);
        VolumeController.Instance.volumeUpdate.AddListener(SetSFXVolume);
        SetSFXVolume();

    }

    private void SetSFXVolume()
    {
        myAudioSource.volume = VolumeController.Instance.SFXVolume;
    }


    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (timer2 > hitBoxDuration)
        {
            myBossAttack.DeactivateCollider();
        }

        targetDist = Vector2.Distance(transform.position, target.transform.position);
        if (timer > attackCooldown)
        {
            if (attackType)
            {
                if (targetDist > stopDist)
                {
                    
                    ChasePlayer();
                }
                else
                {
                    timer = 0;
                    Attack();
                    Onhit.Invoke(); 
                    counter++;
                    
                }
                if (counter > maxAttackCounter)
                {
                    attackType = false;
                    counter = 0;
                }
            }
            else
            {
                timer = 0;
                Shoot();
                counter++;

                if (counter > maxAttackCounter)
                {
                    attackType = true;
                    counter = 0;
                }
            }
        }
        else
        {
            currentSpeed = setSpeed;
        }

    }

    public void Deactive()
    {
        this.enabled = false;
    }

    private void ChasePlayer()
    {
        if (transform.position.x < target.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, currentSpeed * Time.deltaTime);

        myAnimator.SetBool("Move", true);
    }

    private void Attack()
    {

        currentSpeed = 0;
        myBossAttack.ActivateCollider();

        myAudioSource.clip = attackClip;
        myAudioSource.Play();

        myAnimator.SetTrigger("Attack");
        myAnimator.SetBool("Move", false);

        timer2 = 0;


    }

    private void Shoot()
    {
        GameObject thisBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        thisBullet.GetComponent<Knife>().SetTarget(target);
    }


}
