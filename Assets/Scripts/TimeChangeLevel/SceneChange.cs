using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [HideInInspector]
    static public bool isChangeScene = false;
    [HideInInspector]
    static public bool CutScene = false;
    [HideInInspector]
    static public int indexScene;
    [HideInInspector]
    static public string CurrentScene;
    [HideInInspector]
    static public string RestartScene;
    [HideInInspector]
    static public string NextScene;

    private float CountSceneTime = 5;
    private bool CountTime = false;

    public static SceneChange instanceScene;
    void Awake()
    {
        if (instanceScene == null)
        {
            instanceScene = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        CheckCurrentScene();
        SetNextScene();
        SetLevelClerScene();
        StartScene();
        GameOverScene();
        EndScene();
    }
    void CheckCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "StartDisplay")
        {
            CurrentScene = "StartGame";
        }
        if (currentScene.name == "EndDisplay")
        {
            CurrentScene = "EndGame";
        }
        if (currentScene.name == "GameOverDisplay")
        {
            CurrentScene = "GameOver";
        }
    }
    void SetNextScene()
    {
        if (CurrentScene == "StartGame")
        {
            NextScene = "Level1";
            indexScene = 1;
        }
        else if (CurrentScene == "EndGame")
        {
            NextScene = "Level1";
            indexScene = 1;
        }
        else if (CurrentScene == "GameOver")
        {
            NextScene = RestartScene;
            if (RestartScene == "Level1")
            {
                indexScene = 1;
            }
            else if (RestartScene == "Level2")
            {
                indexScene = 2;
            }
            else if (RestartScene == "Level3")
            {
                indexScene = 3;
            }
        }
        else if (CurrentScene == "Level1")
        {
            NextScene = "Level2";
            indexScene = 2;
        }
        else if (CurrentScene == "Level2")
        {
            NextScene = "Level3";
            indexScene = 3;
        }
        else if (CurrentScene == "Level3")
        {
            NextScene = "EndDisplay";
            indexScene = 5;
        }
    }
    void SetLevelClerScene()
    {
        if (CutScene)
        {
            SceneManager.LoadScene("StageClear");
            CutScene = false;
            CountTime = true;
        }
        if (CountSceneTime <= 0)
        {
            CountTime = false;
            CountSceneTime = 5;
            TimeCount.ChangeScene = true;
            isChangeScene = true;
        }
        if (isChangeScene)
        {
            SceneManager.LoadScene(indexScene);
            SceneManager.LoadScene(NextScene);
            isChangeScene = false;
        }
        if (CountTime)
        {
            CountSceneTime -= Time.deltaTime;
        }
    }
    void StartScene()
    {
        if (Input.GetButton("UseItem") && CurrentScene == "StartGame")
        {
            SceneManager.LoadScene(indexScene);
            SceneManager.LoadScene(NextScene);
            CurrentScene = "Level1";
        }
    }
    void GameOverScene()
    {
        if (Input.GetButton("UseItem") && CurrentScene == "GameOver")
        {
            SceneManager.LoadScene(indexScene);
            SceneManager.LoadScene(NextScene);
            CurrentScene = RestartScene;
        }
    }
    void EndScene()
    {
        if (Input.GetButton("UseItem") && CurrentScene == "EndGame")
        {
            SceneManager.LoadScene(indexScene);
            SceneManager.LoadScene(NextScene);
            CurrentScene = "Level1";
            BossFight.EnemyHpBoss = 50;
            PlayerMovement.hpPlayer = 5;
            ItemGunX3.ItemGunX3Count = 0;
            ItemGunRate.ItemGunRateCount = 0;
            Bullet.gunMode = "normal";
            Bullet.curItem = "normal";
            TimeCount.ChangeScene = true;
            PlayerMovement.curCoin = 0;
        }
    }
}
