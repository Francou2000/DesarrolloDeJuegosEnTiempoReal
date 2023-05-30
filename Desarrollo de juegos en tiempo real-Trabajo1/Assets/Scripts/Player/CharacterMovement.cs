using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{

    public bool Defender;
    float timer;
    Rigidbody2D ForceMov;

    public Animator animar;

    void Start()
    {
        timer = 0;
        Defender = false;
        ForceMov = GetComponent<Rigidbody2D>();
        animar = GetComponent<Animator>();
    }


    void Update()
    {

        float MovHorizontal = Input.GetAxis("Horizontal");
        float MovVertical = Input.GetAxis("Vertical");

        if (!Defender)
        {
            if (MovHorizontal == 0 && MovVertical == 0)
            {
                animar.SetFloat("Movimiento", 0);
            }
            else
            {
                animar.SetFloat("Movimiento", 1);
            }
            
            if (Input.GetKey(KeyCode.Space))
            {
                animar.SetFloat("Movimiento", 0);
            }
            
        }
        else
        {
            animar.SetFloat("Movimiento", 0);
            timer += Time.deltaTime;
            if (timer > 0.3)
            {
                Defender = false;
                timer = 0;
            }
        }


        var escalaX = transform.localScale.x;
        var escalaY = transform.localScale.y;
        if (MovHorizontal < 0 && escalaX > 0)
        {
            transform.localScale = new Vector3(-escalaX, escalaY, 1);
        }
        else if(MovHorizontal > 0 && escalaX < 0)
        {
            transform.localScale = new Vector3(-escalaX, escalaY, 1);
        }

    }


    private void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.Space) && !Defender)
        {
            float MovHorizontal = Input.GetAxis("Horizontal");
            float MovVertical = Input.GetAxis("Vertical");

            ForceMov.AddForce(new Vector2(MovHorizontal, MovVertical), ForceMode2D.Force);
        }

    }

}
