using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class BossAttacks : MonoBehaviour
{
    public float Setspeed;
    float speed;
    public float chaseDist;
    public float stopDist;
    private float timer;

    public GameObject target;
    public GameObject bullet;
    public GameObject firePoint;

    private Animator myAnimator;

    [SerializeField] AudioClip attackClip;
    AudioSource myAudioSource;

    private float targetDist;

    bool SetTimer;
    float timer2;
    BossAttack ataque;

    public UnityEvent Onhit = new UnityEvent();
    public UnityEvent BattleStart = new UnityEvent();

    void Start()
    {

        BattleStart.Invoke();
        SetTimer = true;
        timer2 = 0;
        speed = Setspeed;
        ataque = GetComponentInChildren<BossAttack>();
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

        if (timer > 1.5)
        {
            if (targetDist > chaseDist)
            {
                timer = 0;
                Shoot();
            }
            else
            {
                if (SetTimer)
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
                    if (timer2 > 1.5)
                    {
                        SetTimer = true;
                        timer2 = 0;
                        speed = Setspeed;
                        ataque.DesactivarCollider();
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

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        myAnimator.SetBool("Move", true);
    }
    private void Attack()
    {
        //AudioManager.Instance.GolpeDIO();
       
        SetTimer = false;
        speed = 0;
        ataque.ActivarCollider();

        myAudioSource.clip = attackClip; 
        myAudioSource.Play();

        myAnimator.SetTrigger("Attack");
        myAnimator.SetBool("Move", false);

        
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
    }
}
