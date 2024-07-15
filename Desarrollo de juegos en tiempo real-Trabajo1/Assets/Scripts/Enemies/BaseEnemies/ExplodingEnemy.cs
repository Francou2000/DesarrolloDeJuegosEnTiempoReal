using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject exEffect;

    float chaseDistance;
    float stopDistance;
    float movementSpeed;
    int damage;

    [SerializeField] float exRad;
    [SerializeField] float exForce;

    float targetDist;

    void Start()
    {
        SetStats();
    }

    void Update()
    {
        targetDist = Vector2.Distance(transform.position, target.position);
        
        if (targetDist < chaseDistance && targetDist > stopDistance)
        {
            ChasePlayer();
        }
        else
        {
            Explode();
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

        transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
    }

    public void Explode()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, exRad);

        Instantiate(exEffect, transform.position, Quaternion.identity);

        foreach (Collider2D collision in hit) 
        { 
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                Vector2 direction = collision.transform.position - transform.position;
                float distance = 1 + direction.magnitude;
                float finalForce = exForce / distance;
                rb.AddForce(direction * finalForce);
            }

            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.GetDamage(damage);
            }
        }

        

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, exRad);
    }

    void SetStats()
    {
        EnemyData myEnemy = GetComponent<Enemy>().MyEnemyData;
        movementSpeed = myEnemy.MovementSpeed;
        chaseDistance = myEnemy.ChaseDistance;
        stopDistance = myEnemy.AttackDistance;
        damage = myEnemy.Damage;
    }
}
