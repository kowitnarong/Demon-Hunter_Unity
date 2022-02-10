using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZombie : MonoBehaviour
{
    [HideInInspector]
    public GameObject Player;
    public GameObject ZombieDied;
    public float speed = 1.5f;
    [HideInInspector]
    public float TempSpeed;
    [HideInInspector]
    public float FirstMove;
    public int EnemyHp = 1;

    [HideInInspector]
    public int RandomItemGunX3;
    public GameObject ItemGunX3Drop;
    [HideInInspector]
    public int RandomItemGunRate;
    public GameObject ItemGunRateDrop;
    public int AmountItemGunX3;
    public int AmountItemGunRate;
    [HideInInspector]
    public bool ZombieStack = false;

    // Start is called before the first frame update
    public void Start()
    {
        Player = GameObject.Find("Player");
        FirstMove = Time.time;
        TempSpeed = speed;
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }
    public void EnemyDead()
    {
        if (EnemyHp <= 0)
        {
            Instantiate(ZombieDied, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("EnemyDead");
            RandomItemGunX3 = Random.Range(0, 100);
            RandomItemGunRate = Random.Range(0, 100);
            for (int i = 0; i < 10; i++)
            {
                if (RandomItemGunX3 == i)
                {
                    if (ItemGunX3.ItemGunX3Count < AmountItemGunX3)
                    {
                        Instantiate(ItemGunX3Drop, transform.position, transform.rotation);
                        ItemGunX3.ItemGunX3Count += 1;
                    }
                    RandomItemGunX3 = 99;
                    break;
                }
                if (RandomItemGunRate == i)
                {
                    if (ItemGunRate.ItemGunRateCount < AmountItemGunRate)
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
    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Bullet(Clone)" || hitInfo.gameObject.name == "BulletX3L(Clone)"
            || hitInfo.gameObject.name == "BulletX3R(Clone)")
        {
            EnemyHp = EnemyHp - Bullet.bulletDamage;
            Destroy(hitInfo.gameObject);
        }
        if (hitInfo.gameObject.name == "Water")
        {
            speed = (float)(speed / 2.5);
        }
    }
    public void OnTriggerExit2D(Collider2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Water")
        {
            speed = TempSpeed;
        }
    }
}