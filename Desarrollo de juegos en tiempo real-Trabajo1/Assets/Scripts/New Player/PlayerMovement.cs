using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager myInputManager = new InputManager();
    private PlayerAnimatorController myAnimatorController;
    private Rigidbody2D myRigidbody;
    private bool canMove = true;
    public int speedMultiply = 1;

    public bool CanMove { set { canMove = value; } }
    public PlayerAnimatorController MyAnimatorController => myAnimatorController;
    void Start()
    {
        myAnimatorController = new PlayerAnimatorController(GetComponent<Animator>());
        myRigidbody = GetComponent<Rigidbody2D>();
    }

  
    private void FixedUpdate()
    {
        if (canMove)
        {
            myInputManager.MovementInput();
            myRigidbody.AddForce(new Vector2(myInputManager.MovHorizontal, myInputManager.MovVertical) * speedMultiply, ForceMode2D.Force);
            myAnimatorController.MovementUpdate(myInputManager.MovHorizontal, myInputManager.MovVertical);
            if (myInputManager.MovHorizontal < 0)
            {
                transform.localScale = new Vector3(-1.4594f, transform.localScale.y, 1);
            }
            else
            {
                transform.localScale = new Vector3(1.4594f, transform.localScale.y, 1);
            }
        }
        else
        {
            myRigidbody.velocity = Vector3.zero;
            myAnimatorController.MovementUpdate(0, 0);
        }

        //if (!Input.GetKey(KeyCode.Space) && !Defender)
        //{
        //    float MovHorizontal = multiplicadorVel * Input.GetAxis("Horizontal");
        //    float MovVertical = multiplicadorVel * Input.GetAxis("Vertical");

        //    ForceMov.AddForce(new Vector2(MovHorizontal, MovVertical), ForceMode2D.Force);
        //}
    }

    public IEnumerator SpeedUp(int duration)
    {
        speedMultiply = 2;
        yield return new WaitForSeconds(duration);
        speedMultiply = 1;
    }
}
