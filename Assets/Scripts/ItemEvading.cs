using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEvading : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Player")
        {
            if (PlayerMovement.EnemyEvade == false)
            {
                FindObjectOfType<AudioManager>().Play("Grab_Item");
                hitInfo.GetComponent<PlayerMovement>().EnableEnemyEvade();
                Destroy(this.gameObject);
            }
        }
    }
}