using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public int health;
    public int dmg;
    float timer;
    bool SetTimer;

    public GameObject powerUp;
    public GameObject spawnPoint;

    void Start()
    {
        SetTimer = false;
        timer = 0;
    }

    void Update()
    {

        if (SetTimer)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                SetTimer = false;
                timer = 0;
            }
        }

        if (health <= 0)
        {
            Death();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AtkDeff>() && SetTimer == false)
        {
            SetTimer = true;
            health -= dmg;
        }
    }

    private void Death()
    {
        Instantiate(powerUp, spawnPoint.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
