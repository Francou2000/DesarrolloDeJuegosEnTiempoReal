using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMusic : MonoBehaviour
{

    [SerializeField] AudioClip m_newmusic;
    [SerializeField] AudioSource m_audiosource;
    [SerializeField] private BossAttacks golpeDIO;
    void Start()
    {
        m_audiosource = GetComponent<AudioSource>();
        golpeDIO.BattleStart.AddListener(NewBattle);
    }

    private void NewBattle()
    {
        m_audiosource.Stop();
        m_audiosource.clip = m_newmusic;
        m_audiosource.Play();

    }
}
