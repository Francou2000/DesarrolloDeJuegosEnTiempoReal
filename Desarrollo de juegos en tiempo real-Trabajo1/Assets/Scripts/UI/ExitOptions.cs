using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOptions : MonoBehaviour
{

    [SerializeField] private GameObject panelToActivate;
    [SerializeField] private GameObject panelToDeactivate;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            panelToActivate.SetActive(true);
            panelToDeactivate.SetActive(false);
        }
    }
}
