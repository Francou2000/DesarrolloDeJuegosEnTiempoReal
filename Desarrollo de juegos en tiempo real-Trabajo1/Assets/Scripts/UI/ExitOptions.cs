using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOptions : MonoBehaviour
{

    public GameObject optionsMenu;  

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            optionsMenu.SetActive(true);
        }
    }
}
