using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMusicVolume : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    // Start is called before the first frame update
    void Start()
    {
        _slider.onValueChanged.AddListener((v) => {
            VolumeController.Instance.SetMusicVolumeTo(v);
        });
        
    }

    
}
