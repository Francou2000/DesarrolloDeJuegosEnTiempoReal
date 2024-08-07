using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class AudioManagerLvl1 : MonoBehaviour
{
    public static AudioManagerLvl1 Instance;
    [SerializeField] AudioClip m_golpeJotaro;
    [SerializeField] AudioClip m_golpeDIO;
    [SerializeField] AudioSource m_audiosource;
    [SerializeField] private PlayerActions golpejotaro;
    [SerializeField] private NDoulAttack golpeNdoul;


    private void Start()
    {
        m_audiosource = GetComponent<AudioSource>();

        golpejotaro.OnHit.AddListener(GolpeJotaro);

    }


    private void Update()
    {
        m_audiosource.volume = VolumeController.Instance.SFXVolume;
    }
    private void GolpeJotaro()
    {

        m_audiosource.clip = m_golpeJotaro;
        m_audiosource.PlayOneShot(m_golpeJotaro);

    }


    public void GolpeDIO()
    {
        m_audiosource.clip = m_golpeDIO;
        m_audiosource.PlayOneShot(m_golpeDIO);
    }
}
