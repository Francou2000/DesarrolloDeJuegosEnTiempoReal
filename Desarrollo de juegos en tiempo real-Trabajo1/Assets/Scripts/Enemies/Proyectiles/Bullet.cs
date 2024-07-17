using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private float lifeSpan = 5f;

    [SerializeField] int damage = 10;

    public GameObject player;
    private Rigidbody2D myRB;
    

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();

        Vector3 direction = player.transform.position - transform.position;
        myRB.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        Destroy(this.gameObject, lifeSpan);
    }

    public void SetTarget(GameObject target)
    {
        player = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth other = collision.GetComponent<PlayerHealth>();
        if (other != null)
        {
            other.GetDamage(damage);

            Destroy(this.gameObject);
        }
    }

}
