using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var l_healthPJ = other.GetComponent<PlayerHealth>();
        if (l_healthPJ != null)
        {
            l_healthPJ.GetDamage(GetComponentInParent<Enemy>().MyEnemyData.Damage);
        }
    }

    public void ActivarCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DesactivarCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
