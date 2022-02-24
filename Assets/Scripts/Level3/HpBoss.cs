using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.SceneManagement;

public class HpBoss : MonoBehaviour
{
    Image timerBar;
    public float maxHP;
    public float HpLeft;
    public int index;
    public string levelName;
    public static bool ChangeScene;

    private void Start()
    {
        timerBar = GetComponent<Image>();
        maxHP = BossFight.EnemyHpBoss;
        HpLeft = maxHP;
    }
    void Update()
    {
        if (HpLeft > 0)
        {
            HpLeft = BossFight.EnemyHpBoss;
            timerBar.fillAmount = HpLeft / maxHP;
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
