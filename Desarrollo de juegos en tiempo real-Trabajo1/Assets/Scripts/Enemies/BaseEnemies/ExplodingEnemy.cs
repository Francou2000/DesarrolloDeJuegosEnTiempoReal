using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : MonoBehaviour
{
    public GameObject target;
    public GameObject exEffect;

    public float chaseDist;
    public float stopDist;
    public float speed;
    public int danio;

    [SerializeField] private float exRad;
    [SerializeField] private float exForce;

    private float targetDist;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        targetDist = Vector2.Distance(transform.position, target.transform.position);
        
        if (targetDist < chaseDist && targetDist > stopDist)
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
        if (transform.position.x < target.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
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

            if (collision.GetComponent<PlayerHealth>())
            {
                collision.GetComponent<PlayerHealth>().GetDamage(danio);
            }
        }

        

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, exRad);
    }
}
