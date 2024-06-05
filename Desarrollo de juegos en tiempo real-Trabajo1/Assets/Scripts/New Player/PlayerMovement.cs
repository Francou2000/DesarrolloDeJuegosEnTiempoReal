using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager myInputManager = new InputManager();
    private PlayerAnimatorController myAnimatorController;
    private Rigidbody2D myRigidbody;

    
    void Start()
    {
        myAnimatorController = new PlayerAnimatorController(GetComponent<Animator>());
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        myInputManager.ActionsInput();
    }

    private void FixedUpdate()
    {

        myInputManager.MovementInput();
        myRigidbody.AddForce(new Vector2(myInputManager.MovHorizontal, myInputManager.MovVertical), ForceMode2D.Force);
        myAnimatorController.MovementUpdate(myInputManager.MovHorizontal, myInputManager.MovVertical);
        if (myInputManager.MovHorizontal != 0)
        {
            transform.localScale = new Vector3(myInputManager.MovHorizontal, transform.localScale.y, 1);
        }
        

        //if (!Input.GetKey(KeyCode.Space) && !Defender)
        //{
        //    float MovHorizontal = multiplicadorVel * Input.GetAxis("Horizontal");
        //    float MovVertical = multiplicadorVel * Input.GetAxis("Vertical");

        //    ForceMov.AddForce(new Vector2(MovHorizontal, MovVertical), ForceMode2D.Force);
        //}
    }
}
