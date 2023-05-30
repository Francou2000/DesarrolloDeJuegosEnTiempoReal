using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemiesTrigger : MonoBehaviour
{
    [SerializeField] public GameObject[] enemies;
    public int spawnenemigos;

    private void ActivateEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            var enemy = enemies[i];
            enemy.SetActive(true);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject cam;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        MainCamera camara;
        camara = cam.GetComponent<MainCamera>();
        camara.numenemigos= spawnenemigos;

        ActivateEnemies();

        Destroy(gameObject);
    }
}
