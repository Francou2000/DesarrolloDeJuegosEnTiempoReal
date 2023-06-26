using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumenParaMusica : MonoBehaviour
{

    [SerializeField] AudioSource m_audiosource;

    // Start is called before the first frame update
    void Start()
    {
        m_audiosource = GetComponent<AudioSource>();
        m_audiosource.volume = VolumeController.Instance.MusicVolume;
    }


}
