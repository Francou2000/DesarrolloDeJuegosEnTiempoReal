using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioClip jotaroHitClip;
    [SerializeField] AudioClip dioHitClip;
    [SerializeField] AudioSource myAudioSource;
    [SerializeField] private PlayerActions jotaroAttack;
    [SerializeField] private BossAttacks dioAttack;

    
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        
        jotaroAttack.OnHit.AddListener(JotaroAttack);
        dioAttack.Onhit.AddListener(DioAttack);

        SetSFXVolume();
        VolumeController.Instance.volumeUpdate.AddListener(SetSFXVolume);
    }


    private void SetSFXVolume()
    {
        myAudioSource.volume = VolumeController.Instance.SFXVolume;
    }
    private void JotaroAttack()
    {

        myAudioSource.clip= jotaroHitClip;
        myAudioSource.PlayOneShot(jotaroHitClip);
       
    }


    public void DioAttack()
    {
        myAudioSource.clip = dioHitClip;
        myAudioSource.PlayOneShot(dioHitClip);
    }
}
