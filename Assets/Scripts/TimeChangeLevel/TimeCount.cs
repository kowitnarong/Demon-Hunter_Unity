using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TimeCount : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 90;
    public float timeLeft;
    public int index;
    public string levelName;
    public static bool ChangeScene;

    private void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            ItemGunX3.ItemGunX3Count = 0;
            ItemGunRate.ItemGunRateCount = 0;
            PlayerMovement.hpPlayer = 5;
            Bullet.gunMode = "normal";
            Bullet.curItem = "normal";
            ChangeScene = true;
            SceneManager.LoadScene(index);
            SceneManager.LoadScene(levelName);
            //Time.timeScale = 0;
        }
    }
}
