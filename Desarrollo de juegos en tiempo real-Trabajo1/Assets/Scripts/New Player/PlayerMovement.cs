using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager myInputManager = new InputManager();
    private Rigidbody2D myRigidbody;

    
    void Start()
    {
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


        //if (!Input.GetKey(KeyCode.Space) && !Defender)
        //{
        //    float MovHorizontal = multiplicadorVel * Input.GetAxis("Horizontal");
        //    float MovVertical = multiplicadorVel * Input.GetAxis("Vertical");

        //    ForceMov.AddForce(new Vector2(MovHorizontal, MovVertical), ForceMode2D.Force);
        //}
    }
}
