using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    private GameObject Player;
    public GameObject EnemyDied;
    private float speed = 1.5f;
    public int EnemyHp = 2;

    private float delayHp;

    int RandomItemGunX3;
    public GameObject ItemGunX3Drop;
    int RandomItemGunRate;
    public GameObject ItemGunRateDrop;

    //private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        delayHp = Time.time;
        //rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Player.transform.position) > 1f)
        {
            RotateTowardsTarget();
        }

        if (EnemyHp <= 0)
        {
            Instantiate(EnemyDied, transform.position, transform.rotation);
            RandomItemGunX3 = Random.Range(0, 100);
            RandomItemGunRate = Random.Range(0, 100);
            for (int i = 0; i < 10; i++)
            {
                if (RandomItemGunX3 == i)
                {
                    if (ItemGunX3.ItemGunX3Count < 2)
                    {
                        Instantiate(ItemGunX3Drop, transform.position, transform.rotation);
                        ItemGunX3.ItemGunX3Count += 1;
                    }
                    RandomItemGunX3 = 99;
                    break;
                }
                if (RandomItemGunRate == i)
                {
                    if (ItemGunRate.ItemGunRateCount < 2)
                    {
                        Instantiate(ItemGunRateDrop, transform.position, transform.rotation);
                        ItemGunRate.ItemGunRateCount += 1;
                    }
                    RandomItemGunRate = 99;
                    break;
                }
            }
            Destroy(gameObject);
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
                EnemyHp = EnemyHp - Bullet.bulletDamage;
                delayHp = Time.time + 0.1f;
            }
            Destroy(hitInfo.gameObject);
        }
    }

    private void RotateTowardsTarget()
    {
        var offset = -90f;
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}