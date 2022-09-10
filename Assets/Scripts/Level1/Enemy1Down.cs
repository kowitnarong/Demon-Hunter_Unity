using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Down : EnemyZombie
{
    public override void Update()
    {
        if (BossFight.BossDead == false)
        {
            if (Time.time < FirstMove + 2.5f)
            {
                //transform.position += MoveY;
                transform.position += Vector3.up * speed * Time.deltaTime;
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