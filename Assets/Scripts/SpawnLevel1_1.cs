using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel1_1 : MonoBehaviour
{

    public Transform EnemySpawnL1;
    public Transform EnemySpawnL2;
    public Transform EnemySpawnL3;

    public Transform EnemySpawnR1;
    public Transform EnemySpawnR2;
    public Transform EnemySpawnR3;

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

    private float Spawn1L;
    private float Spawn2L;

    private float Spawn1R;
    private float Spawn2R;

    private float Spawn1U;
    private float Spawn2U;

    private float Spawn1D;
    private float Spawn2D;

    private float SwitchTime1 = 3.0f;
    private float SwitchTime2 = 4.0f;

    void Start()
    {
        Spawn2L = Time.time;
        Spawn2U = Time.time;
        Spawn2R = Time.time;
        Spawn2D = Time.time;
    }
    void Update()
    {
        if (Spawn1L + 0.0f < Time.time)
        {
            Instantiate(Enemy1PrefabL, EnemySpawnL2.position, EnemySpawnL2.rotation);
            Spawn1L = Time.time + 10.0f;
        }
        if (Spawn1U + 1.0f < Time.time)
        {
            Instantiate(Enemy1PrefabU, EnemySpawnU2.position, EnemySpawnU2.rotation);
            Spawn1U = Time.time + 10.0f;
        }
        if (Spawn1R + 2.0f < Time.time)
        {
            Instantiate(Enemy1PrefabR, EnemySpawnR2.position, EnemySpawnR2.rotation);
            Spawn1R = Time.time + 10.0f;
        }
        if (Spawn1D + 3.0f < Time.time)
        {
            Instantiate(Enemy1PrefabD, EnemySpawnD2.position, EnemySpawnD2.rotation);
            Spawn1L = Time.time + SwitchTime1;
            Spawn1R = Time.time + SwitchTime1;
            Spawn1U = Time.time + SwitchTime1;
            Spawn1D = Time.time + SwitchTime1;
        }

        if (Spawn2L + 5.0f < Time.time)
        {
            Instantiate(Enemy1PrefabL, EnemySpawnL2.position, EnemySpawnL2.rotation);
            Spawn2L = Time.time + 10.0f;
        }
        if (Spawn2U + 5.0f < Time.time)
        {
            Instantiate(Enemy1PrefabU, EnemySpawnU2.position, EnemySpawnU2.rotation);
            Spawn2U = Time.time + 10.0f;
        }
        if (Spawn2R + 5.0f < Time.time)
        {
            Instantiate(Enemy1PrefabR, EnemySpawnR2.position, EnemySpawnR2.rotation);
            Spawn2R = Time.time + 10.0f;
        }
        if (Spawn2D + 5.0f < Time.time)
        {
            Instantiate(Enemy1PrefabD, EnemySpawnD2.position, EnemySpawnD2.rotation);
            Spawn2L = Time.time + SwitchTime2;
            Spawn2R = Time.time + SwitchTime2;
            Spawn2U = Time.time + SwitchTime2;
            Spawn2D = Time.time + SwitchTime2;
        }
    }
}