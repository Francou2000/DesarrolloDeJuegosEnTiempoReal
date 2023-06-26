using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Animator anim;

    private float targetDist;

    bool SetTimer;
    float timer2;
    EnemyAttack ataque;

    void Start()
    {
        SetTimer = true;
        timer2 = 0;
        speed = Setspeed;
        ataque = GetComponentInChildren<EnemyAttack>();

        anim = GetComponent<Animator>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        targetDist = Vector2.Distance(transform.position, target.transform.position);


        if (targetDist > chaseDist && timer > 1.5)
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

        anim.SetBool("Move", true);
    }
    private void Attack()
    {
        SetTimer = false;
        speed = 0;
        ataque.ActivarCollider();

        anim.SetTrigger("Attack");
        anim.SetBool("Move", false);
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
    }
}
