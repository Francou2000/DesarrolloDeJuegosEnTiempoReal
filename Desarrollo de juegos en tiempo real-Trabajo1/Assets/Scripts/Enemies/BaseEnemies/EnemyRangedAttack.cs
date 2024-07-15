using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    float movementSpeed;
    float speed;
    float chaseDistance;
    float stopDistance;
    float timer;
    [SerializeField] Transform target;
    float targetDist;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject firePoint;
    Animator myAnimator;

    private void Start()
    {
        SetStats();
       myAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        targetDist = Vector2.Distance(transform.position, target.position);

        if (targetDist < chaseDistance && targetDist > stopDistance)
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
        if (transform.position.x < target.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        myAnimator.SetBool("Move", true);
    }

    public IEnumerator ShootCoroutine()
    {
        speed = 0;
        myAnimator.SetTrigger("Attack");
        myAnimator.SetBool("Move", false);
        yield return new WaitForSeconds(myAnimator.GetCurrentAnimatorStateInfo(0).length);
        Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        speed = movementSpeed;
        yield return null;
    }

    void SetStats()
    {
        EnemyData myEnemy = GetComponent<Enemy>().MyEnemyData;
        movementSpeed = myEnemy.MovementSpeed;
        chaseDistance = myEnemy.ChaseDistance;
        stopDistance = myEnemy.AttackDistance;
        speed = movementSpeed;
        timer = 0;

    }
}
