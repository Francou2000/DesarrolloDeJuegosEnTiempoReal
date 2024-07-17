using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class BossAttacks : MonoBehaviour
{
    public float setSpeed;
    float currentSpeed;
    public float chaseDist;
    public float stopDist;
    private float timer;
    [SerializeField] float attackCooldown = 1.5f;

    public GameObject target;
    public GameObject bullet;
    public GameObject firePoint;

    private Animator myAnimator;

    [SerializeField] AudioClip attackClip;
    AudioSource myAudioSource;

    private float targetDist;

    bool setTimer;
    float timer2;
    [SerializeField] float colliderDuration = 1.5f;
    BossAttack myBossAttack;

    public UnityEvent Onhit = new UnityEvent();
    public UnityEvent BattleStart = new UnityEvent();

    void Start()
    {

        BattleStart.Invoke();
        setTimer = true;
        timer2 = 0;
        currentSpeed = setSpeed;
        myBossAttack = GetComponentInChildren<BossAttack>();
        myAudioSource = GetComponentInChildren<AudioSource>();

        myAnimator = GetComponent<Animator>();
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

        targetDist = Vector2.Distance(transform.position, target.transform.position);

        if (timer > attackCooldown)
        {
            if (targetDist > chaseDist)
            {
                timer = 0;
                Shoot();
            }
            else
            {
                if (setTimer)
                {
                    if (targetDist < chaseDist && targetDist > stopDist)
                    {
                        ChasePlayer();
                    }
                    else
                    {
                        Attack();
                        Onhit.Invoke();
                    }
                }
                else
                {
                    timer2 += Time.deltaTime;
                    if (timer2 > colliderDuration)
                    {
                        setTimer = true;
                        timer2 = 0;
                        currentSpeed = setSpeed;
                        myBossAttack.DeactivateCollider();
                    }
                }
            }
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
       
        setTimer = false;
        currentSpeed = 0;
        myBossAttack.ActivateCollider();

        myAudioSource.clip = attackClip; 
        myAudioSource.Play();

        myAnimator.SetTrigger("Attack");
        myAnimator.SetBool("Move", false);

        
    }

    private void Shoot()
    {
        GameObject thisBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        thisBullet.GetComponent<Knife>().SetTarget(target);
    }
}
