using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMusicVolume : MonoBehaviour
{
    [SerializeField] private Slider mySlider;
    
    // Start is called before the first frame update
    void Start()
    {
        mySlider.value = VolumeController.Instance.musicVolume;
        mySlider.onValueChanged.AddListener((v) => {
            VolumeController.Instance.SetMusicVolumeTo(v);
            VolumeController.Instance.volumeUpdate.Invoke();
        });
        
    }

    
}
