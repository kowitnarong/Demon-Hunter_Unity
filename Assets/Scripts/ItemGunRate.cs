using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGunRate : MonoBehaviour
{
    public GameObject itemGunRate;
    public Transform CurItemPoint;
    public GameObject Icon;
    static public int ItemGunRateCount = 0;
    void Update()
    {
        if (Input.GetButton("UseItem") && Bullet.curItem == "RateX2")
        {
            if (transform.position == Icon.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Player")
        {
            if (Bullet.curItem == "normal")
            {
                Bullet.curItem = "RateX2";
                Instantiate(itemGunRate, CurItemPoint.position, CurItemPoint.rotation);
                Debug.Log(Bullet.curItem);
            }
            Destroy(gameObject);
        }
    }
}
