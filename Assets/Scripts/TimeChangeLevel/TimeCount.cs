using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TimeCount : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 90;
    float timeLeft;
    public int index;
    public string levelName;

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

            SceneManager.LoadScene(index);

            SceneManager.LoadScene(levelName);
            //Time.timeScale = 0;
        }
    }
}
