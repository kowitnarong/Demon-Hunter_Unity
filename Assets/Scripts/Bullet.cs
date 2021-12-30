using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody2D rb;

    static public int bulletDamage = 1;
    static public string gunMode = "normal";
    static public string curItem = "normal";

    Vector2 movementLeftUp;
    Vector2 movementRightUp;
    Vector2 movementLeftDown;
    Vector2 movementRightDown;

    bool shootLeftUp = false;
    bool shootRightUp = false;
    bool shootLeftDown = false;
    bool shootRightDown = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetButton("NormalFireLeft") && Input.GetButton("NormalFireUp") && gunMode == "normal")
        {
            movementLeftUp.x = -1;
            movementLeftUp.y = 1;
            shootLeftUp = true;
        }
        else if (Input.GetButton("NormalFireRight") && Input.GetButton("NormalFireUp") && gunMode == "normal")
        {
            movementRightUp.x = 1;
            movementRightUp.y = 1;
            shootRightUp = true;
        }
        else if (Input.GetButton("NormalFireLeft") && Input.GetButton("NormalFireDown") && gunMode == "normal")
        {
            movementLeftDown.x = -1;
            movementLeftDown.y = -1;
            shootLeftDown = true;
        }
        else if (Input.GetButton("NormalFireRight") && Input.GetButton("NormalFireDown") && gunMode == "normal")
        {
            movementRightDown.x = 1;
            movementRightDown.y = -1;
            shootRightDown = true;
        }
        else if (Input.GetButton("NormalFireLeft"))
        {
            rb.velocity = -transform.right * speed;
        }
        else if (Input.GetButton("NormalFireRight"))
        {
            rb.velocity = transform.right * speed;
        }
        else if(Input.GetButton("NormalFireUp"))
        {
            rb.velocity = transform.up * speed;
        }
        else if(Input.GetButton("NormalFireDown"))
        {
            rb.velocity = -transform.up * speed;
        }
    }

    void Update()
    {
        if (shootLeftUp)
        {
            rb.MovePosition(rb.position + movementLeftUp * 12.0f * Time.fixedDeltaTime);
        }
        else if (shootRightUp)
        {
            rb.MovePosition(rb.position + movementRightUp * 12.0f * Time.fixedDeltaTime);
        }
        else if (shootLeftDown)
        {
            rb.MovePosition(rb.position + movementLeftDown * 12.0f * Time.fixedDeltaTime);
        }
        else if (shootRightDown)
        {
            rb.MovePosition(rb.position + movementRightDown * 12.0f * Time.fixedDeltaTime);
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Tilemap_SolidBlock")
        {
            Destroy(gameObject);
        }
    }
}
