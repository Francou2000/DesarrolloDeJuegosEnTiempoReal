using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanIdleState : StateMachineBehaviour
{
    public float speed = 3f;
    float currentSpeed;
    public float attackRange = 1f;

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

        Vector2 target = new Vector2(player.position.x, rb.position.y);

        if (Vector2.Distance(player.position, rb.position) >= attackRange)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, currentSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
            animator.SetBool("Movement", true);
        }

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetBool("Movement", false);
            currentSpeed = 0;
            animator.SetTrigger("MeleeAttack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("MeleeAttack");
        animator.ResetTrigger("GetHit");
    }
}
