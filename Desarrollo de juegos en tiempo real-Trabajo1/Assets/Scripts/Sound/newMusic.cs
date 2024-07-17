using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMusic : MonoBehaviour
{

    [SerializeField] AudioClip newMusicClip;
    [SerializeField] AudioSource myAudioSource;
    [SerializeField] private BossAttacks dioAttack;
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        dioAttack.BattleStart.AddListener(NewBattle);
    }

    private void NewBattle()
    {
        myAudioSource.Stop();
        myAudioSource.clip = newMusicClip;
        myAudioSource.Play();

    }
}
