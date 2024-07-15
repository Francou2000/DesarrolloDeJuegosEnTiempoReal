using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRoller : MonoBehaviour
{

    public Sprite[] partSprites;
    float timer;
    float timer2;
    bool attack;
    public GameObject parts;
    Animator myAnimator;

    [SerializeField] private BossHealth boss;

    void Start()
    {
        attack = false;
        myAnimator = GetComponent<Animator>();
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
                parts.GetComponent<SpriteRenderer>().sprite = partSprites[Random.Range(0,6)];
                Instantiate(parts, new Vector3(posSpawn *3f, 0,0f), Quaternion.identity);
            }
            if(timer2 > 10.55f)
            {
                attack = false;
                boss.gameObject.SetActive(true);
            }
        }
        

    }

    void StartAnimation()
    {
        attack = true;
        timer2 = 0;
        myAnimator.SetTrigger("SpecialAttack");
        boss.gameObject.SetActive(false);
    }


}
