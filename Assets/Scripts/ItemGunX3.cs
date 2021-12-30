using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGunX3 : MonoBehaviour
{
    public GameObject itemGunX3;
    public Transform CurItemPoint;
    public GameObject Icon;
    static public int ItemGunX3Count = 0;
    void Update()
    {
        if (Input.GetButton("UseItem") && Bullet.curItem == "X3")
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
                Bullet.curItem = "X3";
                Instantiate(itemGunX3, CurItemPoint.position, CurItemPoint.rotation);
                Debug.Log(Bullet.curItem);
            }
            Destroy(gameObject);
        }
    }
}
