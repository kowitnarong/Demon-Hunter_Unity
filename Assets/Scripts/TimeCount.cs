using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 90;
    float timeLeft;

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
            Time.timeScale = 0;
        }
    }
}
