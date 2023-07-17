using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinalBossPatron : MonoBehaviour
{
    public float Setspeed;
    float speed;
    bool SetTimer;
    float timer2;


    public GameObject target;
    public GameObject bullet;
    public GameObject firePoint;


    private Animator anim;

    public UnityEvent Onhit = new UnityEvent();






    // Start is called before the first frame update
    void Start()
    {
        SetTimer = true;
        timer2 = 0;
        speed = Setspeed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChasePlayer()
    {
        if (transform.position.x < target.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        anim.SetBool("Move", true);
    }

    private void Attack()
    {
        //AudioManager.Instance.GolpeDIO();

        SetTimer = false;
        speed = 0;
        //ataque.ActivarCollider();

        anim.SetTrigger("Attack");
        anim.SetBool("Move", false);


    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
    }


}
