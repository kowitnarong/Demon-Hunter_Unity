using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BossBullet;
    float speed = 1.0f;

    public Rigidbody2D rb;

    public static int EnemyHpBoss = 50;
    private float delayHp;

    float nextFire;
    public float FireRate = 2;

    bool moveLeft = false;
    bool moveRight = false;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
        delayHp = Time.time;
        moveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        BossMovement();
        BossShoot();
    }
    void BossMovement()
    {
        if (moveLeft)
        {
            rb.velocity = -transform.right * speed;
            if (transform.position.x < -1.5)
            {
                moveRight = true;
                moveLeft = false;
            }
        }
        if (moveRight)
        {
            rb.velocity = transform.right * speed;
            if (transform.position.x > 2.5)
            {
                moveLeft = true;
                moveRight = false;
            }
        }
    }
    void BossShoot()
    {
        if (Time.time > nextFire + FireRate)
        {
            Instantiate(BossBullet, firePoint.transform.position, firePoint.rotation);
            nextFire = Time.time;
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Bullet(Clone)" || hitInfo.gameObject.name == "BulletX3L(Clone)"
            || hitInfo.gameObject.name == "BulletX3R(Clone)")
        {
            if (delayHp < Time.time)
            {
                EnemyHpBoss = EnemyHpBoss - Bullet.bulletDamage;
                delayHp = Time.time + 0.1f;
            }
            Debug.Log(EnemyHpBoss);
            Destroy(hitInfo.gameObject);
        }
    }
}
