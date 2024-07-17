using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VolumeController : MonoBehaviour
{

    public static VolumeController Instance;


    public float musicVolume;
    public float SFXVolume;
    public UnityEvent volumeUpdate = new UnityEvent();

    private void Awake()
    {
        if (Instance == null)
        {
            VolumeController.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SetMusicVolumeTo(float volume)
    {
        musicVolume = volume;
    }
    public void SetSFXVolumeTo(float volume)
    {
        SFXVolume = volume;
    }
}
