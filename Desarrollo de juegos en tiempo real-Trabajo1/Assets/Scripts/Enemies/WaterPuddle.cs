using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPuddle : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 0.8f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<HealthPJ>())
        {

            HealthPJ other;
            other = collision.GetComponent<HealthPJ>();
            other.RestarHP(10);
        }


    }
}
