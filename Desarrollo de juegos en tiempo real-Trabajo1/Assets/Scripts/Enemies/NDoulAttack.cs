using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NDoulAttack : MonoBehaviour
{
    public float LongDist;
    public float MidDist;
    public float ShortDist;
    private float timer;

    public GameObject target;
    public GameObject bullet;
    public GameObject SP1;
    public GameObject SP2;
    public GameObject SP3;
    public GameObject SP4;
    public GameObject SP5;
    public GameObject SP6;
    public GameObject SP7;
    public GameObject SP8;
    public GameObject SP9;

    private Animator anim;

    private float targetDist;


    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        targetDist = Vector2.Distance(transform.position, target.transform.position);

        if (timer > 1)
        {
            if (targetDist >= LongDist)
            {
                timer = 0;
                ShootLong();
            }
            else if (targetDist >= MidDist)
            {
                timer = 0;
                ShootMid();
            }
            else if (targetDist >= ShortDist)
            {
                timer = 0;
                ShootShort();
            }
        }
    }

    private void ShootLong()
    {
        Instantiate(bullet, SP1.transform.position, Quaternion.identity);
        Instantiate(bullet, SP2.transform.position, Quaternion.identity);
        Instantiate(bullet, SP3.transform.position, Quaternion.identity);
    }
    private void ShootMid()
    {
        Instantiate(bullet, SP4.transform.position, Quaternion.identity);
        Instantiate(bullet, SP5.transform.position, Quaternion.identity);
        Instantiate(bullet, SP6.transform.position, Quaternion.identity);
    }
    private void ShootShort()
    {
        Instantiate(bullet, SP7.transform.position, Quaternion.identity);
        Instantiate(bullet, SP8.transform.position, Quaternion.identity);
        Instantiate(bullet, SP9.transform.position, Quaternion.identity);
    }
}
