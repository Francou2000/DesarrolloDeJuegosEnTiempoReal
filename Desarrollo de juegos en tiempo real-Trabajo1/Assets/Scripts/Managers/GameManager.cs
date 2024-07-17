using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    [SerializeField] private BossHealth firstBoss = null;
    [SerializeField] private BossHealth secondBoss = null;
    [SerializeField] private BossHealth finalBoss = null;
    [SerializeField] private BossHealth seanBoss = null;
    [SerializeField] private PlayerHealth PJ = null;


    // Start is called before the first frame update
    void Start()
    {
        PJ.OnDeath.AddListener(LoadDefeatScene);
        firstBoss.OnDeath.AddListener(LoadLevel2);
        secondBoss.OnDeath.AddListener(LoadLevel4);
        finalBoss.OnDeath.AddListener(LoadWinScene);
        seanBoss.OnDeath.AddListener(LoadLevel3);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLevel4() 
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
