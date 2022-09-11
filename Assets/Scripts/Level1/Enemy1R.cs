using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy1R : EnemyZombie
{
    public override void Update()
    {
        if (BossFight.BossDead == false)
        {
            if (Time.time < FirstMove + 2.5f)
            {
                transform.position += Vector3.left * 1.5f * Time.deltaTime;
            }
            else if (Time.time > FirstMove + 2.5f)
            {
                if (!ZombieStack)
                {
                    if (PlayerMovement.EnemyEvade)
                    {
                        EnemyEvade();
                    }
                    else
                    {
                        EnemyChasing();
                    }
                }
            }
        }
        else
        {
            EnemyHp = 0;
        }

        EnemyDead();
    }
}