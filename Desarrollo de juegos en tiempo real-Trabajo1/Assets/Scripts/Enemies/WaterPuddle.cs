using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPuddle : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 0.8f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealth>())
        {
            PlayerHealth other;
            other = collision.GetComponent<PlayerHealth>();
            other.GetDamage(10);
            Rigidbody2D rb = collision.GetComponentInParent<Rigidbody2D>();
            Vector2 direction = collision.transform.position - transform.position;
            float distance = 1 + direction.magnitude;
            float finalForce = 50 / distance;
            rb.AddForce(direction * finalForce);
        }
    }
}
