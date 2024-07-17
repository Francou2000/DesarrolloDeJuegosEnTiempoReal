using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController
{
    private Animator myAnimator;

    public PlayerAnimatorController(Animator animator)
    {
        myAnimator = animator;
    }

    public void MovementUpdate(float movVertical, float movHorizontal)
    {
        if (movHorizontal == 0 &&  movVertical == 0)
        {
            myAnimator.SetFloat("Movimiento", 0);
        }
        else
        {
            myAnimator.SetFloat("Movimiento", 1);
        }
        
    }

    public void TriggerAnimation(string id)
    {
        myAnimator.SetTrigger(id);
    }
    public void ResetTrigger(string id)
    {
        myAnimator.ResetTrigger(id);
    }

    public float GetAnimationLenght()
    {
        return myAnimator.GetCurrentAnimatorStateInfo(0).length;
    }
}
