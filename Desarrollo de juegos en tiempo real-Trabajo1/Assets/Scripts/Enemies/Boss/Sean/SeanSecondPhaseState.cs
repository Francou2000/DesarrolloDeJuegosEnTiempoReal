using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanSecondPhaseState : StateMachineBehaviour
{
    public float attackRange = 5f;

    Transform player;
    Rigidbody2D rb;
    EnemyLookAt boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<EnemyLookAt>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        if (Vector2.Distance(player.position, rb.position) >= attackRange)
        {
            animator.SetTrigger("RangeAttack");
        }
        else
        {
            animator.SetBool("Movement", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("RangeAttack");
        animator.ResetTrigger("TakeHit");
    }
}
