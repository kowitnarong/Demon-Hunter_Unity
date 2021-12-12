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

    private bool EnemyLOn = false;
    private bool EnemyROn = false;
    private bool EnemyUOn = false;
    private bool EnemyDOn = false;

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

    void Start()
    {
        Spawn1L = Time.time;
        Spawn2L = Time.time;
        Instantiate(Enemy1PrefabL, EnemySpawnL2.position, EnemySpawnL2.rotation);
    }
    void Update()
    {
        if (Spawn1L + 5.0f < Time.time)
        {
            Instantiate(Enemy1PrefabL, EnemySpawnL2.position, EnemySpawnL2.rotation);
            Spawn1L = Time.time;
        }
        if (Spawn2L + 10.0f < Time.time)
        {
            Instantiate(Enemy1PrefabL, EnemySpawnL1.position, EnemySpawnL1.rotation);
            Instantiate(Enemy1PrefabL, EnemySpawnL2.position, EnemySpawnL2.rotation);
            Instantiate(Enemy1PrefabL, EnemySpawnL3.position, EnemySpawnL3.rotation);
            Spawn2L = Time.time;
            if (!EnemyROn)
            {
                Spawn1R = Time.time;
                Spawn2R = Time.time;
                EnemyROn = true;
            }
        }

        if (Spawn1R + 5.0f < Time.time)
        {
            Instantiate(Enemy1PrefabR, EnemySpawnR2.position, EnemySpawnR2.rotation);
            Spawn1R = Time.time;
        }
        if (Spawn2R + 10.0f < Time.time)
        {
            Instantiate(Enemy1PrefabR, EnemySpawnR1.position, EnemySpawnR1.rotation);
            Instantiate(Enemy1PrefabR, EnemySpawnR2.position, EnemySpawnR2.rotation);
            Instantiate(Enemy1PrefabR, EnemySpawnR3.position, EnemySpawnR3.rotation);
            Spawn2R = Time.time;
            if (!EnemyUOn)
            {
                Spawn1U = Time.time;
                Spawn2U = Time.time;
                EnemyUOn = true;
            }
        }

        if (Spawn1U + 10.0f < Time.time)
        {
            Instantiate(Enemy1PrefabU, EnemySpawnU2.position, EnemySpawnU2.rotation);
            Spawn1U = Time.time;
        }
        if (Spawn2U + 15.0f < Time.time)
        {
            Instantiate(Enemy1PrefabU, EnemySpawnU1.position, EnemySpawnU1.rotation);
            Instantiate(Enemy1PrefabU, EnemySpawnU2.position, EnemySpawnU2.rotation);
            Instantiate(Enemy1PrefabU, EnemySpawnU3.position, EnemySpawnU3.rotation);
            Spawn2U = Time.time;
            if (!EnemyDOn)
            {
                Spawn1D = Time.time;
                Spawn2D = Time.time;
                EnemyDOn = true;
            }
        }

        if (Spawn1D + 10.0f < Time.time)
        {
            Instantiate(Enemy1PrefabD, EnemySpawnD2.position, EnemySpawnD2.rotation);
            Spawn1D = Time.time;
        }
        if (Spawn2D + 15.0f < Time.time)
        {
            Instantiate(Enemy1PrefabD, EnemySpawnD1.position, EnemySpawnD1.rotation);
            Instantiate(Enemy1PrefabD, EnemySpawnD2.position, EnemySpawnD2.rotation);
            Instantiate(Enemy1PrefabD, EnemySpawnD3.position, EnemySpawnD3.rotation);
            Spawn2D = Time.time;
        }
    }
}