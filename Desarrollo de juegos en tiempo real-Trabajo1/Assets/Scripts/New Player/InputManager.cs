using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private float movHorizontal = 0;
    private float movVertical = 0;
    private bool punch = false;
    //private bool powerUp = false;

    public float MovHorizontal => movHorizontal;
    public float MovVertical => movVertical;
    public bool Punch => punch;
    //public bool PowerUp => powerUp;

    public InputManager() { }


    public void ActionsInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // The player shoots with "Space"
        {
            punch = true;
        }
        else
        {
            punch = false;
        }

        //if (Input.GetKeyDown(KeyCode.Mouse1)) // The player uses the powerUP with "Mouse1" (right click)
        //{
        //    powerUp = true;
        //}
        //else
        //{
        //    powerUp = false;
        //}

    }

    public void MovementInput()
    {
        movHorizontal = Input.GetAxis("Horizontal"); //The player moves left with "A" and right with "D"
        movVertical = Input.GetAxis("Vertical"); //The player looks up with "W" and down with "S"
    }
}
