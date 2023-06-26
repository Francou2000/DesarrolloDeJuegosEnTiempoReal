using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AtkDeff : MonoBehaviour
{
    public UnityEvent Onhit = new UnityEvent();
    public Animator animar;
    float timer = 0;


    void Start()
    {
        animar = GetComponent<Animator>();

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Onhit.Invoke();
            Debug.Log("ORA ORA");

            animar.SetBool("Ataca", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {

            animar.SetBool("Ataca", false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (animar.GetBool("Defiende"))
        {
            timer += Time.deltaTime;
            if (timer > 0.3)
            {
                animar.SetBool("Defiende", false);
                timer = 0;
            }
        }
    }

    

    public void Defender()
    {
        
        animar.SetBool("Defiende", true);
    }
}
