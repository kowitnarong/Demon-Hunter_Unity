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

    public GameObject ItemMoneyDrop;
    [HideInInspector]
    public int RandomItemMoney;
    [HideInInspector]
    public int RandomItemGunX3;
    public GameObject ItemGunX3Drop;
    [HideInInspector]
    public int RandomItemGunRate;
    public GameObject ItemGunRateDrop;
    public int AmountItemGunX3;
    public int AmountItemGunRate;

    void Start()
    {
        Player = GameObject.Find("Player");
        delayHp = Time.time;
    }

    void Update()
    {
        SetMovement();
        FlyEnemyDead();
    }
    void SetMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Player.transform.position) > 1f)
        {
            RotateTowardsTarget();
        }
    }
    void FlyEnemyDead()
    {
        if (EnemyHp <= 0)
        {
            Instantiate(EnemyDied, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("EnemyDead");
            RandomItemGunX3 = Random.Range(0, 100);
            RandomItemGunRate = Random.Range(0, 100);
            RandomItemMoney = Random.Range(0, 100);
            if (RandomItemMoney >= 20 && RandomItemMoney < 40)
            {
                Instantiate(ItemMoneyDrop, transform.position, ItemMoneyDrop.transform.rotation);
                RandomItemMoney = 99;
            }
            else if (RandomItemGunX3 >= 10 && RandomItemGunX3 < 20)
            {
                if (ItemGunX3.ItemGunX3Count < AmountItemGunX3)
                {
                    Instantiate(ItemGunX3Drop, transform.position, ItemGunX3Drop.transform.rotation);
                    ItemGunX3.ItemGunX3Count += 1;
                }
                RandomItemGunX3 = 99;
            }
            else if (RandomItemGunRate >= 0 && RandomItemGunRate < 10)
            {
                if (ItemGunRate.ItemGunRateCount < AmountItemGunRate)
                {
                    Instantiate(ItemGunRateDrop, transform.position, ItemGunRateDrop.transform.rotation);
                    ItemGunRate.ItemGunRateCount += 1;
                }
                RandomItemGunRate = 99;
            }
            CountZombieDead.Count += 1;
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