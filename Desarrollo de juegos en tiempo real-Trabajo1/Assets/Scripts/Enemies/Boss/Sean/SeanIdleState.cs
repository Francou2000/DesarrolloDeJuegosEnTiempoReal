using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanIdleState : StateMachineBehaviour
{
    public float attackRange = .7f;

    private float time = 1f;
    private float timer = 0;

    Transform player;
    Rigidbody2D rb;
    EnemyLookAt boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<EnemyLookAt>();

        timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        timer += Time.deltaTime;

        if (Vector2.Distance(player.position, rb.transform.position) >= attackRange)
        {
            animator.SetBool("Movement", true);
        }
        else if (timer >= time)
        {
            animator.SetBool("Movement", false);
            animator.SetTrigger("MeleeAttack");
            timer = 0;  
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("MeleeAttack");
        animator.ResetTrigger("TakeHit");
    }
}
