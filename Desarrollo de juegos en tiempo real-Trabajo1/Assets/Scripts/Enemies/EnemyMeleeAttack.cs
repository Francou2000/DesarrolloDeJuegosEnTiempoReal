using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public float Setspeed;
    float speed;
    public float chaseDist;
    public float stopDist;
    GameObject target;
    private Animator anim;

    private float targetDist;

    bool SetTimer;
    float timer;
    EnemyAttack ataque;

    void Start()
    {
        SetTimer = true;
        timer = 0;
        speed = Setspeed;
        ataque = GetComponentInChildren<EnemyAttack>();

        target = GameObject.FindWithTag("Player");

        anim = GetComponent<Animator>();


    }


    void Update()
    {
        targetDist = Vector2.Distance(transform.position, target.transform.position);

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
            timer += Time.deltaTime;
            if (timer > 2)
            {
                SetTimer = true;
                timer = 0;
                speed = Setspeed;
                ataque.DesactivarCollider();
            }
        }

    }

    private void ChasePlayer()
    {
        if (transform.position.x < target.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(2, 2, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-2, 2, 1);
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

}
