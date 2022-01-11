using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate;
    private float TempFireRate;
    private float nextFire = 0.0f;
    public GameObject bulletPrefab;
    public GameObject bulletXL;
    public GameObject bulletXM;
    public GameObject bulletXR;

    bool useItem = false;
    float ChangeItemTime = 0.0f;
    float resetItemTime = 0.0f;
    public float DurationGunX3 = 15.0f;
    public float DurationGunRate = 10.0f;

    void Start()
    {
        ChangeItemTime = Time.time;
        TempFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("UseItem") && useItem == false)
        {
            Debug.Log(Bullet.curItem);
            if (Bullet.curItem == "X3")
            {
                Bullet.gunMode = Bullet.curItem;
                resetItemTime = DurationGunX3;
                useItem = true;
                ChangeItemTime = Time.time;
            }
            if (Bullet.curItem == "RateX2")
            {
                fireRate = fireRate / 2;
                resetItemTime = DurationGunRate;
                useItem = true;
                ChangeItemTime = Time.time;
            }
        }
        if (Time.time > ChangeItemTime + resetItemTime && useItem == true)
        {
            Bullet.curItem = "normal";
            Bullet.gunMode = "normal";
            fireRate = TempFireRate;
            useItem = false;
        }

        if (Input.GetButton("NormalFireLeft") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (Bullet.gunMode == "normal")
            {
                Shoot();
            }
            else if (Bullet.gunMode == "X3")
            {
                ShootX3();
            }
        }
        else if (Input.GetButton("NormalFireRight") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (Bullet.gunMode == "normal")
            {
                Shoot();
            }
            else if (Bullet.gunMode == "X3")
            {
                ShootX3();
            }
        }
        else if (Input.GetButton("NormalFireUp") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (Bullet.gunMode == "normal")
            {
                Shoot();
            }
            else if (Bullet.gunMode == "X3")
            {
                ShootX3();
            }
        }
        else if (Input.GetButton("NormalFireDown") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (Bullet.gunMode == "normal")
            {
                Shoot();
            }
            else if (Bullet.gunMode == "X3")
            {
                ShootX3();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootX3()
    {
        Instantiate(bulletXL, firePoint.position, firePoint.rotation);
        Instantiate(bulletXM, firePoint.position, firePoint.rotation);
        Instantiate(bulletXR, firePoint.position, firePoint.rotation);
    }
}
