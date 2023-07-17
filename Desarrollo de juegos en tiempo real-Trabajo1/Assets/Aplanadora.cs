using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplanadora : MonoBehaviour
{

    public Sprite[] SpritePartes;
    float timer;
    float timer2;
    bool attack;
    public GameObject Partes;
    Animator anim;

    [SerializeField] private BossHealth boss;

    void Start()
    {
        attack = false;
        anim = GetComponent<Animator>();
        timer = 0;
        timer2 = 0;

        boss.SpecialAttack.AddListener(StartAnimation);
    }

    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if( attack )
        {
            if (timer > 1)
            {
                timer = 0;
                int posSpawn = Random.Range(-5, 0);
                Partes.GetComponent<SpriteRenderer>().sprite = SpritePartes[Random.Range(0,6)];
                Instantiate(Partes, new Vector3(posSpawn *3f, 0,0f), Quaternion.identity);
            }
            if(timer2 > 10.08f)
            {
                anim.SetBool("SpecialAttack", false);
                attack = false;
                boss.gameObject.SetActive(true);
            }
        }
        

    }

    void StartAnimation()
    {
        attack = true;
        timer2 = 0;
        anim.SetBool("SpecialAttack", true);
        boss.gameObject.SetActive(false);
    }


}
