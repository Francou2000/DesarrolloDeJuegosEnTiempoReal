using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;

    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        var dt = Time.deltaTime;
        transform.position = new Vector2(transform.position.x + -speed * transform.localScale.x * dt, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthPJ>())
        {
            HealthPJ other;
            other = collision.GetComponent<HealthPJ>();
            other.RestarHP(10);
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Vector2 direction = collision.transform.position - transform.position;
            float distance = 1 + direction.magnitude;
            float finalForce = 50 / distance;
            rb.AddForce(direction * finalForce);
            Destroy(this.gameObject);
        }
    }
}
