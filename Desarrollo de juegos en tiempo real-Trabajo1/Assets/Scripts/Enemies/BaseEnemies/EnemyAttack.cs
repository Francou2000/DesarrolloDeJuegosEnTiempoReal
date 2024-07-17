using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth healthPJ = other.GetComponent<PlayerHealth>();
        if (healthPJ != null)
        {
            healthPJ.GetDamage(GetComponentInParent<Enemy>().MyEnemyData.Damage);
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
