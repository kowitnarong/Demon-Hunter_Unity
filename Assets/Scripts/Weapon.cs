using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 0.3f;
    private float nextFire = 0.0F;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("NormalFireLeft") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
        else if (Input.GetButton("NormalFireRight") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
        else if (Input.GetButton("NormalFireUp") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
        else if (Input.GetButton("NormalFireDown") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
