using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AtkDeff : MonoBehaviour
{
    public UnityEvent Onhit = new UnityEvent();
    public Animator animar;
    float timer = 0;
    float timerATK = 0;

    void Start()
    {
        animar = GetComponent<Animator>();

    }

    void Update()
    {
        timerATK += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Onhit.Invoke();
            Debug.Log("ORA ORA");

            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            timerATK = 0;
            animar.SetBool("Ataca", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            
        }
        if (timerATK > 0.3 && Input.GetKey(KeyCode.Space) == false)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 1);
            }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            timerATK = 0;
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
                transform.position = new Vector3(transform.position.x, transform.position.y, 1);
                
            }
        }
    }

    

    public void Defender()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        timerATK = 0;
        animar.SetBool("Defiende", true);
    }
}
