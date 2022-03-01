using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel3 : MonoBehaviour
{
    public int HpChangeStateBoss = 25;
    public Transform EnemySpawnL1;
    public Transform EnemySpawnL2;
    public Transform EnemySpawnL3;
    public Transform EnemySpawnL4;
    public Transform EnemySpawnL5;

    public Transform EnemySpawnR1;
    public Transform EnemySpawnR2;
    public Transform EnemySpawnR3;
    public Transform EnemySpawnR4;
    public Transform EnemySpawnR5;

    public Transform EnemySpawnU1;
    public Transform EnemySpawnU2;
    public Transform EnemySpawnU3;

    public Transform EnemySpawnD1;
    public Transform EnemySpawnD2;
    public Transform EnemySpawnD3;

    public GameObject Enemy1PrefabL;
    public GameObject Enemy1PrefabR;
    public GameObject Enemy1PrefabU;
    public GameObject Enemy1PrefabD;
    public GameObject FlyEnemyPrefab;

    private float Spawn1L;
    private float Spawn2L;

    private float Spawn1R;
    private float Spawn2R;

    private float Spawn3L;

    private float Spawn3R;

    private float SwitchTime1 = 7.0f;

    void Start()
    {
        Spawn1L = Time.time;
        Spawn1R = Time.time;
        Spawn2L = Time.time;
        Spawn2R = Time.time;
        Spawn3L = Time.time;
        Spawn3R = Time.time;
    }
    void Update()
    {
        if (BossFight.BossDead == false)
        {
            SetSpawnPattern();
        }
    }
    void SetSpawnPattern()
    {
        if (Spawn1L + 2.0f < Time.time)
        {
            Instantiate(Enemy1PrefabL, EnemySpawnL1.position, EnemySpawnL1.rotation);
            Spawn1L = Time.time + 10.0f;
        }
        if (Spawn1R + 2.0f < Time.time)
        {
            Instantiate(Enemy1PrefabR, EnemySpawnR1.position, EnemySpawnR1.rotation);
            Spawn1R = Time.time + 10.0f;
        }
        if (Spawn2L + 2.0 < Time.time && BossFight.EnemyHpBoss <= HpChangeStateBoss)
        {
            Instantiate(Enemy1PrefabL, EnemySpawnL2.position, EnemySpawnL2.rotation);
            Spawn2L = Time.time + 10.0f;
        }
        if (Spawn2R + 2.0 < Time.time && BossFight.EnemyHpBoss <= HpChangeStateBoss)
        {
            Instantiate(Enemy1PrefabR, EnemySpawnR2.position, EnemySpawnR2.rotation);
            Spawn2R = Time.time + 10.0f;
        }
        if (Spawn3L + 2.0f < Time.time)
        {
            Instantiate(Enemy1PrefabL, EnemySpawnL3.position, EnemySpawnL3.rotation);
            Spawn3L = Time.time + 10.0f;
        }
        if (Spawn3R + 2.0f < Time.time)
        {
            Instantiate(Enemy1PrefabR, EnemySpawnR3.position, EnemySpawnR3.rotation);
            Spawn1L = Time.time + SwitchTime1;
            Spawn1R = Time.time + SwitchTime1;
            Spawn2L = Time.time + SwitchTime1;
            Spawn2R = Time.time + SwitchTime1;
            Spawn3L = Time.time + SwitchTime1;
            Spawn3R = Time.time + SwitchTime1;
        }
        if (PlayerMovement.hpPlayer <= 0)
        {
            Spawn1L = Time.time;
            Spawn1R = Time.time;
            Spawn2L = Time.time;
            Spawn2R = Time.time;
            Spawn3L = Time.time;
            Spawn3R = Time.time;
        }
    }
}