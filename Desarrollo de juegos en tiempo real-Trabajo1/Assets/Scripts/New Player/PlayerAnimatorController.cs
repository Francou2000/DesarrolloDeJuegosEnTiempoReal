using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController
{
    private Animator _animator;

    public PlayerAnimatorController(Animator animator)
    {
        _animator = animator;
    }

    public void MovementUpdate(float movVertical, float movHorizontal)
    {
        if (movHorizontal == 0 &&  movVertical == 0)
        {
            _animator.SetFloat("Movimiento", 0);
        }
        else
        {
            _animator.SetFloat("Movimiento", 1);
        }
        
    }
}
