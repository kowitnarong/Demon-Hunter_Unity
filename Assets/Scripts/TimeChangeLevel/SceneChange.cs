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
        if (CurrentScene == "Level1")
        {
            NextScene = "Level2";
            indexScene = 1;
        }
        else if (CurrentScene == "Level2")
        {
            NextScene = "Level3";
            indexScene = 2;
        }
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
}
