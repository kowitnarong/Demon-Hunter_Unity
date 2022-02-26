using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel2 : MonoBehaviour
{

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

    private float Spawn1U;
    private float Spawn2U;

    private float Spawn1D;
    private float Spawn2D;

    private float Spawn3L;
    private float Spawn4L;

    private float Spawn3R;
    private float Spawn4R;

    private float SwitchTime1 = 3.0f;
    private float SwitchTime2 = 4.0f;
    private float SwitchTime3 = 10.0f;

    void Start()
    {
        Spawn2L = Time.time;
        Spawn2U = Time.time;
        Spawn2R = Time.time;
        Spawn2D = Time.time;
        Spawn3L = Time.time;
        Spawn3R = Time.time;
        Spawn4L = Time.time;
        Spawn4R = Time.time;
    }
    void Update()
    {
        SetSpawnPattern();
    }
    void SetSpawnPattern()
    {
        if (Spawn1L + 0.0f < Time.time)
        {
            Instantiate(Enemy1PrefabL, EnemySpawnL1.position, EnemySpawnL1.rotation);
            Spawn1L = Time.time + 10.0f;
        }
        if (Spawn1U + 1.0f < Time.time)
        {
            Instantiate(Enemy1PrefabU, EnemySpawnU1.position, EnemySpawnU1.rotation);
            Spawn1U = Time.time + 10.0f;
        }
        if (Spawn1R + 2.0f < Time.time)
        {
            Instantiate(Enemy1PrefabR, EnemySpawnR1.position, EnemySpawnR1.rotation);
            Spawn1R = Time.time + 10.0f;
        }
        if (Spawn1D + 3.0f < Time.time)
        {
            Instantiate(Enemy1PrefabD, EnemySpawnD1.position, EnemySpawnD1.rotation);
            Spawn1L = Time.time + SwitchTime1;
            Spawn1R = Time.time + SwitchTime1;
            Spawn1U = Time.time + SwitchTime1;
            Spawn1D = Time.time + SwitchTime1;
        }

        if (Spawn2L + 5.0f < Time.time)
        {
            Instantiate(Enemy1PrefabL, EnemySpawnL3.position, EnemySpawnL3.rotation);
            Spawn2L = Time.time + 10.0f;
        }
        if (Spawn2U + 5.0f < Time.time)
        {
            Instantiate(Enemy1PrefabU, EnemySpawnU3.position, EnemySpawnU3.rotation);
            Spawn2U = Time.time + 10.0f;
        }
        if (Spawn2R + 5.0f < Time.time)
        {
            Instantiate(Enemy1PrefabR, EnemySpawnR3.position, EnemySpawnR3.rotation);
            Spawn2R = Time.time + 10.0f;
        }
        if (Spawn2D + 5.0f < Time.time)
        {
            Instantiate(Enemy1PrefabD, EnemySpawnD3.position, EnemySpawnD3.rotation);
            Spawn2L = Time.time + SwitchTime2;
            Spawn2R = Time.time + SwitchTime2;
            Spawn2U = Time.time + SwitchTime2;
            Spawn2D = Time.time + SwitchTime2;
        }

        if (Spawn3L + 10.0f < Time.time)
        {
            Instantiate(FlyEnemyPrefab, EnemySpawnL4.position, EnemySpawnL4.rotation);
            Spawn3L = Time.time + 100.0f;
        }
        if (Spawn3R + 20.0f < Time.time)
        {
            Instantiate(FlyEnemyPrefab, EnemySpawnR4.position, EnemySpawnR4.rotation);
            Spawn3R = Time.time + 100.0f;
        }
        if (Spawn4L + 30.0f < Time.time)
        {
            Instantiate(FlyEnemyPrefab, EnemySpawnL5.position, EnemySpawnL5.rotation);
            Spawn4L = Time.time + 100.0f;
        }
        if (Spawn4R + 40.0f < Time.time)
        {
            Instantiate(FlyEnemyPrefab, EnemySpawnR5.position, EnemySpawnR5.rotation);
            Spawn3L = Time.time + SwitchTime3;
            Spawn3R = Time.time + SwitchTime3;
            Spawn4L = Time.time + SwitchTime3;
            Spawn4R = Time.time + SwitchTime3;
        }
        if (PlayerMovement.hpPlayer <= 0)
        {
            Spawn2L = Time.time;
            Spawn2U = Time.time;
            Spawn2R = Time.time;
            Spawn2D = Time.time;
            Spawn3L = Time.time;
            Spawn3R = Time.time;
            Spawn4L = Time.time;
            Spawn4R = Time.time;
        }
    }
}