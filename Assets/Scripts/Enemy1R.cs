using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1R : MonoBehaviour
{
    private GameObject Player;
    private float speed = 1.0f;
    private float FirstMove;
    private int EnemyHp = 1;

    Vector3 MoveX = new Vector3(0.005f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        FirstMove = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time < FirstMove + 3.0f)
        {
            transform.position -= MoveX;
        }
        else if (Time.time > FirstMove + 3.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }

        if (EnemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Bullet(Clone)")
        {
            EnemyHp = EnemyHp - Bullet.bulletDamage;
            Destroy(hitInfo.gameObject);
        }
    }
}
