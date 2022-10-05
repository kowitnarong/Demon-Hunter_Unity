using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart_Game()
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene("Level1");
        SceneChange.CurrentScene = "Level1";
        AudioManager.ChangeScene = true;
        BossFight.EnemyHpBoss = 50;
        BossFight.BossDead = false;
        PlayerMovement.hpPlayer = 5;
        ItemGunX3.ItemGunX3Count = 0;
        ItemGunRate.ItemGunRateCount = 0;
        Bullet.gunMode = "normal";
        Bullet.curItem = "normal";
        PlayerMovement.curCoin = 0;
        PlayerMovement.EnemyEvade = false;
        CountZombieDead.Count = 0;
    }
}
