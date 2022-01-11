using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    static public int hpPlayer = 3;
    static public int curCoin = 0;
    private float hpCDCheck = 0.0f;
    public float hpCD = 2.0f;

    public Rigidbody2D rb;
    public Animator animator;
    private float fireRate = 0.2f;
    private float nextFire = 0.0F;

    Vector2 movement;

    Vector2 FireDirection;

    private bool fireOn;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Right", FireDirection.x);
        animator.SetFloat("Up", FireDirection.y);
        animator.SetBool("FireOn", fireOn);

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
            FireDirection.x = 0;
        }

        if (nextFire < Time.time)
        {
            fireOn = false;
        }

    }
    void FixedUpdate()
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
}