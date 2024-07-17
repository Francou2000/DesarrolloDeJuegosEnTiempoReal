using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanIdleState : StateMachineBehaviour
{
    public float attackRange = 1.5f;

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

        if (Vector2.Distance(player.position, rb.transform.position) >= attackRange)
        {
            animator.SetBool("Movement", true);
        }
        else
        {
            animator.SetBool("Movement", false);
            animator.SetTrigger("MeleeAttack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("MeleeAttack");
        animator.ResetTrigger("TakeHit");
    }
}
