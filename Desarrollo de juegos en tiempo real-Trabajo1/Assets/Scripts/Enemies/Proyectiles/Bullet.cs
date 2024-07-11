using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public GameObject player;
    private Rigidbody2D rb;
    

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        Destroy(this.gameObject, 2);

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
