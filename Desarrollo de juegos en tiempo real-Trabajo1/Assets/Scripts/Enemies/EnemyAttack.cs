using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var l_healthPJ = other.GetComponent<HealthPJ>();
        if (l_healthPJ != null)
        {
            l_healthPJ.RestarHP(20);

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
