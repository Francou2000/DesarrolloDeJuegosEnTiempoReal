using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioClip m_golpeJotaro;
    [SerializeField] AudioClip m_golpeDIO;
    [SerializeField] AudioSource m_audiosource;
    [SerializeField] private AtkDeff golpejotaro;

    private void Start()
    {
        golpejotaro.Onhit.AddListener(GolpeJotaro);
    }



    private void GolpeJotaro()
    {
        m_audiosource.clip= m_golpeJotaro;
        m_audiosource.Play();
    }

    private void GolpeDIO()
    {
        m_audiosource.clip = m_golpeDIO;
        m_audiosource.Play();
    }
}
