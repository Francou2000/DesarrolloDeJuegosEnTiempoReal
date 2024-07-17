using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth healthPJ = other.GetComponent<PlayerHealth>();
        if (healthPJ != null)
        {
            healthPJ.GetDamage(damage);
        }
    }

    public void ActivateCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DeactivateCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}

