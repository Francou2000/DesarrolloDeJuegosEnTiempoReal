using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOptions : MonoBehaviour
{
    /*
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
    */

    public GameObject pauseMenuUI;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
}
