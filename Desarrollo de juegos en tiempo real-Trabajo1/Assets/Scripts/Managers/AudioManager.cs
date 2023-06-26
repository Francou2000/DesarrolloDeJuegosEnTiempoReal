using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.ShaderKeywordFilter;
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
        m_audiosource = GetComponent<AudioSource>();
        
        golpejotaro.Onhit.AddListener(GolpeJotaro);
    }


    private void Update()
    {
        m_audiosource.volume = VolumeController.Instance.SFXVolume;
    }
    private void GolpeJotaro()
    {

        m_audiosource.clip= m_golpeJotaro;
        m_audiosource.PlayOneShot(m_golpeJotaro);
       
    }


    private void GolpeDIO()
    {
        m_audiosource.clip = m_golpeDIO;
        m_audiosource.Play();
    }
}
