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
    public string levelName;
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }
    void Update()
    {
        TimeCheck();
    }
    void TimeCheck()
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
            SceneChange.CutScene = true;
            SceneChange.CurrentScene = levelName;
        }
    }
}
