using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.SceneManagement;

public class HpBoss : MonoBehaviour
{
    Image timerBar;
    [HideInInspector]
    public float maxHP;
    [HideInInspector]
    public float HpLeft;
    public string levelName;
    [HideInInspector]
    public static bool ChangeScene;

    private void Start()
    {
        timerBar = GetComponent<Image>();
        maxHP = BossFight.EnemyHpBoss;
        HpLeft = maxHP;
    }
    void Update()
    {
        BossDead();
    }
    void BossDead()
    {
        if (HpLeft > 0)
        {
            BossFight.BossDead = false;
            HpLeft = BossFight.EnemyHpBoss;
            timerBar.fillAmount = HpLeft / maxHP;
        }
        else
        {
            BossFight.BossDead = true;
        }
        if (BossFight.BossDead)
        {
            Invoke("ChangeSceneEnd", 4);
        }
    }
    void ChangeSceneEnd()
    {
        ItemGunX3.ItemGunX3Count = 0;
        ItemGunRate.ItemGunRateCount = 0;
        PlayerMovement.hpPlayer = 5;
        Bullet.gunMode = "normal";
        Bullet.curItem = "normal";
        SceneManager.LoadScene("EndDisplay");
        //Time.timeScale = 0;
    }
}
