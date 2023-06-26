using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    public float speed;
    public float chaseDist;
    public float stopDist;
    private float timer;

    public GameObject target;
    public GameObject bullet;
    public GameObject firePoint;
    private Animator anim;

    private float targetDist;


    private void Start()
    {
       anim = GetComponent<Animator>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        targetDist = Vector2.Distance(transform.position, target.transform.position);

        if (targetDist < chaseDist && targetDist > stopDist)
        {
            ChasePlayer();
        }
        else if (timer > 3)
        {
            timer = 0;
            Shoot();
        }
    }

    private void ChasePlayer()
    {
        if (transform.position.x < target.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(2, 2, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-2, 2, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, Quaternion.identity);

        anim.SetTrigger("Attack");
    }
}
