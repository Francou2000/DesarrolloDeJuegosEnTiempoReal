using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplanadora : MonoBehaviour
{

    public Sprite[] SpritePartes;
    float timer;
    public GameObject Partes;



    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            int posSpawn = Random.Range(-3, 1);
            Partes.GetComponent<SpriteRenderer>().sprite = SpritePartes[Random.Range(0,6)];
            Instantiate(Partes, new Vector3(posSpawn *5f, 0,0f), Quaternion.identity);
        }

    }

}
