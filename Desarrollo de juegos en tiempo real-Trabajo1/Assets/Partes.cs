using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -5 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var pj = collision.GetComponent<HealthPJ>();
        if (pj)
        {
            pj.RestarHP(50);
        }
    }
}