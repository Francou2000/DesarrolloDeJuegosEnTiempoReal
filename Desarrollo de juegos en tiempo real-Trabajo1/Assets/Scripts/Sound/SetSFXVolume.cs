using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSFXVolume : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        _slider.value = VolumeController.Instance.SFXVolume;
        _slider.onValueChanged.AddListener((v) => {
            VolumeController.Instance.SetSFXVolumeTo(v);
            VolumeController.Instance.volumeUpdate.Invoke();
        });

    }

}
