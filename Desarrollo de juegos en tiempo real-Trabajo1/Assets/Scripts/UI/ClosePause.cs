using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClosePause : MonoBehaviour
{
    Button myButton;

    public GameObject pauseMenuUI;

    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(ResumeGame);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }
}
