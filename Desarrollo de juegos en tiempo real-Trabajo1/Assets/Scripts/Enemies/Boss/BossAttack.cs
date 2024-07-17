using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth l_healthPJ = other.GetComponent<PlayerHealth>();
        if (l_healthPJ != null)
        {
            l_healthPJ.GetDamage(damage);
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

