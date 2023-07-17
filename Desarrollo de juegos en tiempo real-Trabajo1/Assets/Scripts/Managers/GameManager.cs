using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    [SerializeField] private BossHealth firstBoss;
    [SerializeField] private BossHealth secondBoss;
    [SerializeField] private BossHealth finalBoss;
    [SerializeField] private HealthPJ PJ;


    // Start is called before the first frame update
    void Start()
    {
        PJ.OnDeath.AddListener(LoadDefeatScene);
        firstBoss.OnDeath.AddListener(LoadLevel2);
        secondBoss.OnDeath.AddListener(LoadLevel3);
        finalBoss.OnDeath.AddListener(LoadWinScene);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void LoadLevel3() 
    {
        SceneManager.LoadScene("FinalBoss");
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
