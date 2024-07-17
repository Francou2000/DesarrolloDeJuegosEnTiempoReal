using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed;
    [SerializeField] float lifeSpan = 5f;

    [SerializeField] int damage = 10;

    private GameObject player;
    private Rigidbody2D myRB;
    


    void Start()
    {
        
        myRB = GetComponent<Rigidbody2D>();

        Vector3 direction = player.transform.position - transform.position;
        myRB.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

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
