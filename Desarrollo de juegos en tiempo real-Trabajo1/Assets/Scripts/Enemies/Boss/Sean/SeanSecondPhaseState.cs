using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanSecondPhaseState : StateMachineBehaviour
{
    public float speed = 3f;
    float currentSpeed;
    public float attackRange = 3f;

    Transform player;
    Rigidbody2D rb;
    EnemyLookAt boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<EnemyLookAt>();
        currentSpeed = speed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        if (Vector2.Distance(player.position, rb.position) >= attackRange)
        {
            animator.SetTrigger("RangeAttack");
        }

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetBool("Movement", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("RangeAttack");
        animator.ResetTrigger("GetHit");
    }
}
