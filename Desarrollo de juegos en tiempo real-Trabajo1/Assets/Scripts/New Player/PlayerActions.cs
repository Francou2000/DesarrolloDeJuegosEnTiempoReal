using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private InputManager myInputManager = new InputManager();
    private PlayerAnimatorController myAnimatorController;
    private Collider2D myAttackCollider;
    private bool canAttack = true;

    public bool CanAttack { set { canAttack = value; } }
    void Start()
    {
        myAnimatorController = new PlayerAnimatorController(GetComponent<Animator>());
        myAttackCollider = GetComponent<Collider2D>();
    }


    void Update()
    {
        if (canAttack)
        {
            myInputManager.ActionsInput();
            BasicAttack();
            //ZaWarudo();
        }

    }

    void BasicAttack()
    {
        if (myInputManager.Punch)
        {
            myAnimatorController.TriggerAnimation("Attack");
            StartCoroutine(AttackColliderCoroutine());
        }
    }

    public IEnumerator AttackColliderCoroutine()
    {
        GetComponentInParent<PlayerMovement>().CanMove = false;
        yield return new WaitForSeconds(0.5f);
        myAttackCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        myAttackCollider.enabled = false;
        GetComponentInParent<PlayerMovement>().CanMove = true;
    }

    //void ZaWarudo()
    //{

    //}
}
