using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{

    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        SetMusicVolume();
        VolumeController.Instance.volumeUpdate.AddListener(SetMusicVolume);

    }

    private void SetMusicVolume()
    {
        myAudioSource.volume = VolumeController.Instance.musicVolume;
    }


}
