using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<HealthPJ>();

            if (player)
            {
                player.TriggerInvincibility();
                Destroy(gameObject);
            }
        }
    }
}

