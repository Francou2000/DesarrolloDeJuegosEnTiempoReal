using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneButton : MonoBehaviour
{
    Button myButton;
    [SerializeField] string sceneName;


    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
