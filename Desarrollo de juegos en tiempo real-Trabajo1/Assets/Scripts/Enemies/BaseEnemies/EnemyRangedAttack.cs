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
            StartCoroutine(ShootCoroutine());
        }
    }

    private void ChasePlayer()
    {
        if (transform.position.x < target.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        anim.SetBool("Move", true);
    }

    public IEnumerator ShootCoroutine()
    {
        anim.SetTrigger("Attack");
        anim.SetBool("Move", false);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        yield return null;
    }
}
