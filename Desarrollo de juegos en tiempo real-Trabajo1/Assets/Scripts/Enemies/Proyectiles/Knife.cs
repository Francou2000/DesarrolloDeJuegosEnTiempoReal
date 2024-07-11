using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed;

    private GameObject player;
    private Rigidbody2D rb;
    

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        Destroy(this.gameObject, 5);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.GetComponent<PlayerHealth>())
        {
            PlayerHealth other;
            other = collision.GetComponent<PlayerHealth>();
            other.GetDamage(10);

            Destroy(this.gameObject);

        }

    }


}
