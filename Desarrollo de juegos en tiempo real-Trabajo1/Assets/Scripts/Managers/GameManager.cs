using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    [SerializeField] private BossHealth boss;
    [SerializeField] private HealthPJ PJ;


    // Start is called before the first frame update
    void Start()
    {
        PJ.OnDeath.AddListener(LoadDefeatScene);
        boss.OnDeath.AddListener(LoadWinScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene("VictoryScreen");
    }
    public void LoadDefeatScene()
    {
        SceneManager.LoadScene("DefeatScreen");
    }
}
