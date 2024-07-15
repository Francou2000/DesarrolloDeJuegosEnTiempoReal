using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    float movementSpeed;
    float speed;
    float chaseDistance;
    float stopDistance;
    [SerializeField] Transform target;
    private float targetDistance;
    private Animator myAnimator;

    bool setTimer;
    float timer;
    EnemyAttack myAttack;

    void Start()
    {
        SetStats();
        myAttack = GetComponentInChildren<EnemyAttack>();
        myAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        targetDistance = Vector2.Distance(transform.position, target.position);

        if (setTimer)
        {
            if (targetDistance < chaseDistance && targetDistance > stopDistance)
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
                setTimer = true;
                timer = 0;
                speed = movementSpeed;
                myAttack.DesactivarCollider();
            }
        }

    }

    private void ChasePlayer()
    {
        //float pos = target.position.x - transform.position.x;
        //pos = pos/Mathf.Abs(pos);
        //gameObject.transform.localScale = new Vector3(pos, 1, 1);

        if (transform.position.x < target.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        myAnimator.SetBool("Move", true);
    }

    private void Attack()
    {
        setTimer = false;
        speed = 0;
        myAttack.ActivarCollider();

        myAnimator.SetTrigger("Attack");
        myAnimator.SetBool("Move", false);
    }

    void SetStats()
    {
        EnemyData myEnemy = GetComponent<Enemy>().MyEnemyData;
        movementSpeed = myEnemy.MovementSpeed;
        chaseDistance = myEnemy.ChaseDistance;
        stopDistance = myEnemy.AttackDistance;
        speed = movementSpeed;
        setTimer = true;
        timer = 0;

    }
}
