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
        }
    }
}
