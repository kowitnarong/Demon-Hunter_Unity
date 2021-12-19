using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Up : MonoBehaviour
{
    private GameObject Player;
    public GameObject ZombieDied;
    private float speed = 2.0f;
    private float FirstMove;
    private int EnemyHp = 1;

    Vector3 MoveY = new Vector3(0.0f, 0.005f, 0);

    private bool ZombieStack = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        FirstMove = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time < FirstMove + 2.5f)
        {
            transform.position -= MoveY;
        }
        else if (Time.time > FirstMove + 2.5f)
        {
            if (!ZombieStack)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            }
        }

        if (EnemyHp <= 0)
        {
            Instantiate(ZombieDied, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Bullet(Clone)" || hitInfo.gameObject.name == "BulletX3L(Clone)"
            || hitInfo.gameObject.name == "BulletX3R(Clone)")
        {
            EnemyHp = EnemyHp - Bullet.bulletDamage;
            Destroy(hitInfo.gameObject);
        }

        if (hitInfo.gameObject.name == "Enemy1D(Clone)" || hitInfo.gameObject.name == "Enemy1U(Clone)"
            || hitInfo.gameObject.name == "Enemy1L(Clone)" || hitInfo.gameObject.name == "Enemy1R(Clone)")
        {
            speed = 0;
        }
    }

    void OnTriggerStay2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Enemy1D(Clone)"
            || hitInfo.gameObject.name == "Enemy1U(Clone)"
            || hitInfo.gameObject.name == "Enemy1L(Clone)"
            || hitInfo.gameObject.name == "Enemy1R(Clone)")
        {
            ZombieStack = true;
            speed = -2.0f;
            transform.position = Vector2.MoveTowards(transform.position, hitInfo.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Enemy1D(Clone)")
        {
            ZombieStack = false;
            speed = 2.0f;
        }
        else if (hitInfo.gameObject.name == "Enemy1U(Clone)")
        {
            ZombieStack = false;
            speed = 2.0f;
        }
        else if (hitInfo.gameObject.name == "Enemy1L(Clone)")
        {
            ZombieStack = false;
            speed = 2.0f;
        }
        else if (hitInfo.gameObject.name == "Enemy1R(Clone)")
        {
            ZombieStack = false;
            speed = 2.0f;
        }
    }
}