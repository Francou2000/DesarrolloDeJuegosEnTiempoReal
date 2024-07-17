using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    float movementSpeed;
    float currentSpeed;
    float chaseDistance;
    float stopDistance;
    [SerializeField] Transform target;
    private float targetDistance;
    private Animator myAnimator;

    bool setTimer;
    float timer;
    [SerializeField] float attackCooldown = 2;

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
            if (timer > attackCooldown)
            {
                setTimer = true;
                timer = 0;
                currentSpeed = movementSpeed;
                myAttack.DeactivateCollider();
            }
        }

    }

    private void ChasePlayer()
    {
        if (transform.position.x < target.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, currentSpeed * Time.deltaTime);

        myAnimator.SetBool("Move", true);
    }

    private void Attack()
    {
        setTimer = false;
        currentSpeed = 0;
        myAttack.ActivateCollider();

        myAnimator.SetTrigger("Attack");
        myAnimator.SetBool("Move", false);
    }

    void SetStats()
    {
        EnemyData myEnemy = GetComponent<Enemy>().MyEnemyData;
        movementSpeed = myEnemy.MovementSpeed;
        chaseDistance = myEnemy.ChaseDistance;
        stopDistance = myEnemy.AttackDistance;
        currentSpeed = movementSpeed;
        setTimer = true;
        timer = 0;

    }
}
