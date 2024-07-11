using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinalBossPatron : MonoBehaviour
{
    public float Setspeed;
    float speed;
    bool SetTimer;
    float timer;
    float timer2;
    public float stopDist;

    public GameObject target;
    public GameObject bullet;
    public GameObject firePoint;

    private float targetDist;

    private Animator anim;
    EnemyAttack ataque;

    public UnityEvent Onhit = new UnityEvent();


    bool attackType;
    int contador;



    // Start is called before the first frame update
    void Start()
    {
        SetTimer = true;
        timer = 0;
        timer2 = 0;
        speed = Setspeed;
        ataque = GetComponentInChildren<EnemyAttack>();
        anim = GetComponent<Animator>();
        attackType = true;
        contador = 0;
        GetComponent<BossHealth>().NoLife.AddListener(Deactive);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (timer2 > 0.5f)
        {
            ataque.DesactivarCollider();
        }

        targetDist = Vector2.Distance(transform.position, target.transform.position);
        if (timer > 1.5)
        {
            if (attackType)
            {
                if (targetDist > stopDist)
                {
                    
                    ChasePlayer();
                }
                else
                {
                    timer = 0;
                    Attack();
                    Onhit.Invoke(); 
                    contador++;
                    
                }
                if (contador > 4)
                {
                    attackType = false;
                    contador = 0;
                }
            }
            else
            {
                timer = 0;
                Shoot();
                contador++;

                if (contador > 4)
                {
                    attackType = true;
                    contador = 0;
                }
            }
        }
        else
        {
            speed = Setspeed;
        }

    }

    public void Deactive()
    {
        this.enabled = false;
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
        ataque.ActivarCollider();

        anim.SetTrigger("Attack");
        anim.SetBool("Move", false);

        timer2 = 0;


    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
    }


}
