using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] EnemyData myEnemyData;
    int health;
    Animator myAnimator;
    AudioSource myAudioSource;
    [SerializeField] AudioClip hitClip;

    public EnemyData MyEnemyData => myEnemyData;
    

    void Start()
    {
        health = myEnemyData.MaxHealth;
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>(); 
        VolumeController.Instance.volumeUpdate.AddListener(SetSFXVolume);
        SetSFXVolume();

    }

    private void SetSFXVolume()
    {
        myAudioSource.volume = VolumeController.Instance.SFXVolume;
    }

    public void GetDamage(int damage)
    {
        health-= damage;

        myAudioSource.clip = hitClip;
        myAudioSource.Play();

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
