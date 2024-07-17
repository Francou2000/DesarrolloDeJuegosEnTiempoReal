using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSFXVolume : MonoBehaviour
{
    [SerializeField] private Slider mySlider;

    // Start is called before the first frame update
    void Start()
    {
        mySlider.value = VolumeController.Instance.SFXVolume;
        mySlider.onValueChanged.AddListener((v) => {
            VolumeController.Instance.SetSFXVolumeTo(v);
            VolumeController.Instance.volumeUpdate.Invoke();
        });

    }

}
