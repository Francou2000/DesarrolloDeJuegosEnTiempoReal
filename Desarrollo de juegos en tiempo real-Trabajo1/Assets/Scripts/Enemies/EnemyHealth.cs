using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int actualHealth;
    [SerializeField] int maxHealth;

    void Start()
    {
        actualHealth = maxHealth;
    }

    public void GetDamage(int damage)
    {
        actualHealth -= damage;
        if (actualHealth < 0 )
        {
            Destroy(gameObject);
        }
    }
}
