using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    float velRot;
    public float velocidad;
    public float rayCastDist;
    public LayerMask layerMask;

    void Start()
    {
        velRot = 10;
    }


    void Update()
    {
  
        velRot += 50 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, velRot, 0);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, rayCastDist, layerMask);
        if (hit)
        {
            velocidad *= -1;
            rayCastDist *= -1;
        }
        transform.Translate(0, velocidad * Time.deltaTime, 0);

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + rayCastDist));
    }
    
}
