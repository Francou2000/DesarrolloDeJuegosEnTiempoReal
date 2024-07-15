using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] EnemyData myEnemyData;
    int health;
    private Animator myAnimator;


    public EnemyData MyEnemyData => myEnemyData;
    

    void Start()
    {
        health = myEnemyData.MaxHealth;
        myAnimator = GetComponent<Animator>();
    }

    public void GetDamage(int damage)
    {
        health-= damage;
        if (health <= 0)
        {
            GetKilled();
        }

        myAnimator.SetTrigger("TakeHit");
        myAnimator.SetBool("Move", false);
    }

    public void GetKilled()
    {
        Destroy(this.gameObject);
    }
}
