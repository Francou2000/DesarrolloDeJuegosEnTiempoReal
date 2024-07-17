using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanSecondPhaseState : StateMachineBehaviour
{
    public float attackRange = 5f;

    [SerializeField] private float shootTime = 1f;
    private float timer = 0;
    [SerializeField] private float cooldownTime = 7f;

    private int shootCounter = 0;
    [SerializeField] private int shootInterval = 5;

    private bool onCooldown = false; 

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

        timer += Time.deltaTime;

        if (!onCooldown)
        {
            if (Vector2.Distance(player.position, rb.transform.position) <= attackRange)
            {
                animator.SetBool("Movement", true);
            }
            else if (timer >= shootTime)
            {
                animator.SetBool("Movement", false);
                animator.SetTrigger("RangeAttack");
                timer = 0;
                shootCounter++;
            }
            if (shootCounter >= shootInterval)  
            {
                onCooldown = true;
                shootCounter = 0;
            }
        }
        else 
        { 
            animator.SetBool("Movement", false);
            
            if (timer >= cooldownTime)
            {
                onCooldown = false;
                timer = 0;  
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("RangeAttack");
        animator.ResetTrigger("TakeHit");
    }
}
