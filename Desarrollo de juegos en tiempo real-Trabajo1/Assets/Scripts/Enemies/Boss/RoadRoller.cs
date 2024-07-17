using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRoller : MonoBehaviour
{
    float timer;
    [SerializeField] float attackTimer = 1;
    float timer2;
    [SerializeField] float stopAttackingTimer = 10.55f;
    bool attack;
    public GameObject parts;
    Animator myAnimator;

    [SerializeField] int spawnPointsAmmount = 6;

    [SerializeField] private BossHealth bossHealth;

    void Start()
    {
        attack = false;
        myAnimator = GetComponent<Animator>();
        timer = 0;
        timer2 = 0;

        bossHealth.SpecialAttack.AddListener(StartAnimation);
    }

    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (attack)
        {
            if (timer > attackTimer)
            {
                timer = 0;
                int posSpawn = Random.Range(-(spawnPointsAmmount - 1), 0);
                Instantiate(parts, new Vector3(posSpawn * 3f, 0, 0f), Quaternion.identity);
            }
            if (timer2 > stopAttackingTimer)
            {
                attack = false;
                bossHealth.gameObject.SetActive(true);
            }
        }


    }

    void StartAnimation()
    {
        attack = true;
        timer2 = 0;
        myAnimator.SetTrigger("SpecialAttack");
        bossHealth.gameObject.SetActive(false);
    }


}