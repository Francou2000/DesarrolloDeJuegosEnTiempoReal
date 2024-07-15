using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public int health;
    public int dmg;

    public GameObject[] powerUp;
    public GameObject spawnPoint;
    private GameObject player;

    
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player.transform.position.y < spawnPoint.transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerActions>())
        {
            health -= dmg;
            if (health <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        Instantiate(powerUp[Random.Range(0,4)], spawnPoint.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
