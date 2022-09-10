using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    private float TempMoveSpeed;
    static public int hpPlayer = 5;
    static public int curCoin = 0;
    private float hpCDCheck = 0.0f;
    public float hpCD = 2.0f;
    static public bool EnemyEvade = false;

    public Rigidbody2D rb;
    public Animator animator;
    private float fireRate = 0.2f;
    private float nextFire = 0.0F;

    public string LevelRestart;

    Vector2 movement;

    Vector2 FireDirection;

    private bool fireOn;

    void Start()
    {
        TempMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        GetAxisMovement();
        SetAnimatePlayer();
        SetFireDirection();
        IsPlayerDead();

        if (Input.GetButton("Level1"))
        {
            BossFight.EnemyHpBoss = 50;
            BossFight.BossDead = false;
            hpPlayer = 5;
            ItemGunX3.ItemGunX3Count = 0;
            ItemGunRate.ItemGunRateCount = 0;
            Bullet.gunMode = "normal";
            Bullet.curItem = "normal";
            AudioManager.ChangeScene = true;
            SceneChange.CurrentScene = "Level1";
            SceneManager.LoadScene(0);
            SceneManager.LoadScene("Level1");
        }
        else if (Input.GetButton("Level2"))
        {
            BossFight.EnemyHpBoss = 50;
            BossFight.BossDead = false;
            hpPlayer = 5;
            ItemGunX3.ItemGunX3Count = 0;
            ItemGunRate.ItemGunRateCount = 0;
            Bullet.gunMode = "normal";
            Bullet.curItem = "normal";
            AudioManager.ChangeScene = true;
            SceneChange.CurrentScene = "Level2";
            SceneManager.LoadScene(1);
            SceneManager.LoadScene("Level2");
        }
        else if (Input.GetButton("Level3"))
        {
            BossFight.EnemyHpBoss = 50;
            BossFight.BossDead = false;
            hpPlayer = 5;
            ItemGunX3.ItemGunX3Count = 0;
            ItemGunRate.ItemGunRateCount = 0;
            Bullet.gunMode = "normal";
            Bullet.curItem = "normal";
            AudioManager.ChangeScene = true;
            SceneChange.CurrentScene = "Level3";
            SceneManager.LoadScene(2);
            SceneManager.LoadScene("Level3");
        }
    }
    void FixedUpdate()
    {
        SetMovementPlayer();
    }

    public void EnableEnemyEvade()
    {
        EnemyEvade = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("DisableEnemyEvade", 5.0f);
    }

    void DisableEnemyEvade()
    {
        EnemyEvade = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void GetAxisMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void SetAnimatePlayer()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Right", FireDirection.x);
        animator.SetFloat("Up", FireDirection.y);
        animator.SetBool("FireOn", fireOn);
    }

    void SetFireDirection()
    {
        if (Input.GetButton("NormalFireLeft") && Time.time > nextFire)
        {
            fireOn = true;
            nextFire = Time.time + fireRate;
            FireDirection.x = -1;
            FireDirection.y = 0;
        }
        else if (Input.GetButton("NormalFireRight") && Time.time > nextFire)
        {
            fireOn = true;
            nextFire = Time.time + fireRate;
            FireDirection.x = 1;
            FireDirection.y = 0;
        }
        else if (Input.GetButton("NormalFireUp") && Time.time > nextFire)
        {
            fireOn = true;
            nextFire = Time.time + fireRate;
            FireDirection.y = 1;
            FireDirection.x = 0;
        }
        else if (Input.GetButton("NormalFireDown") && Time.time > nextFire)
        {
            fireOn = true;
            nextFire = Time.time + fireRate;
            FireDirection.y = -1;
        }
        if (nextFire < Time.time)
        {
            fireOn = false;
        }
    }

    void IsPlayerDead()
    {
        //HP Check
        if (hpPlayer <= 0)
        {
            BossFight.EnemyHpBoss = 50;
            hpPlayer = 5;
            curCoin = 0;
            ItemGunX3.ItemGunX3Count = 0;
            ItemGunRate.ItemGunRateCount = 0;
            Bullet.gunMode = "normal";
            Bullet.curItem = "normal";
            SceneChange.RestartScene = LevelRestart;
            SceneManager.LoadScene("GameOverDisplay");
        }
    }

    void SetMovementPlayer()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Enemy1D(Clone)" || hitInfo.gameObject.name == "Enemy1U(Clone)"
            || hitInfo.gameObject.name == "Enemy1L(Clone)" || hitInfo.gameObject.name == "Enemy1R(Clone)")
        {
            if (Time.time > hpCDCheck + hpCD)
            {
                hpPlayer -= 1;
                FindObjectOfType<AudioManager>().Play("PlayerGetHit");
                if (hitInfo.gameObject.name == "Enemy1U(Clone)")
                {
                    hitInfo.gameObject.GetComponent<Enemy1Up>().EnemyHp = 0;
                }
                if (hitInfo.gameObject.name == "Enemy1D(Clone)")
                {
                    hitInfo.gameObject.GetComponent<Enemy1Down>().EnemyHp = 0;
                }
                if (hitInfo.gameObject.name == "Enemy1L(Clone)")
                {
                    hitInfo.gameObject.GetComponent<Enemy1L>().EnemyHp = 0;
                }
                if (hitInfo.gameObject.name == "Enemy1R(Clone)")
                {
                    hitInfo.gameObject.GetComponent<Enemy1R>().EnemyHp = 0;
                }
                hpCDCheck = Time.time;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Water")
        {
            moveSpeed = (float)(moveSpeed / 2);
        }
        if (hitInfo.gameObject.name == "FlyEnemy(Clone)")
        {
            if (Time.time > hpCDCheck + hpCD)
            {
                hpPlayer -= 1;
                FindObjectOfType<AudioManager>().Play("PlayerGetHit");
                if (hitInfo.gameObject.name == "FlyEnemy(Clone)")
                {
                    hitInfo.gameObject.GetComponent<FlyEnemy>().EnemyHp = 0;
                }
                hpCDCheck = Time.time;
            }
        }
        if (hitInfo.gameObject.name == "BossBullet(Clone)")
        {
            if (Time.time > hpCDCheck + hpCD)
            {
                hpPlayer -= 1;
                FindObjectOfType<AudioManager>().Play("PlayerGetHit");
                Destroy(hitInfo.gameObject);
                hpCDCheck = Time.time;
            }
        }
        if (hitInfo.gameObject.name == "Money(Clone)")
        {
            curCoin += 1;
            FindObjectOfType<AudioManager>().Play("Grab_Item");
            Destroy(hitInfo.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Water")
        {
            moveSpeed = TempMoveSpeed;
        }
    }
}