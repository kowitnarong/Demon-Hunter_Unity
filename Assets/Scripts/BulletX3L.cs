using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletX3L : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody2D rb;

    Vector2 movementLeftUp;
    Vector2 movementRightUp;
    Vector2 movementLeftDown;
    Vector2 movementRightDown;

    bool shootLeft = false;
    bool shootRight = false;
    bool shootUp = false;
    bool shootDown = false;

    // Start is called before the first frame update
    void Start()
    {
        movementLeftUp.x = -0.5f;
        movementLeftUp.y = 0.5f;

        movementRightUp.x = 0.5f;
        movementRightUp.y = 0.5f;

        movementLeftDown.x = -0.5f;
        movementLeftDown.y = -0.5f;

        movementRightDown.x = 0.5f;
        movementRightDown.y = -0.5f;

        if (Input.GetButton("NormalFireLeft"))
        {
            shootLeft = true;
        }
        else if (Input.GetButton("NormalFireRight"))
        {
            shootRight = true;
        }
        else if (Input.GetButton("NormalFireUp"))
        {
            shootUp = true;
        }
        else if (Input.GetButton("NormalFireDown"))
        {
            shootDown = true;
        }
    }

    void Update()
    {
        if (shootLeft)
        {
            rb.MovePosition(rb.position + movementLeftDown * speed * Time.fixedDeltaTime);
        }
        else if (shootRight)
        {
            rb.MovePosition(rb.position + movementRightUp * speed * Time.fixedDeltaTime);
        }
        else if (shootUp)
        {
            rb.MovePosition(rb.position + movementLeftUp * speed * Time.fixedDeltaTime);
        }
        else if (shootDown)
        {
            rb.MovePosition(rb.position + movementRightDown * speed * Time.fixedDeltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("collision name = " + hitInfo.gameObject.name);
        if (hitInfo.gameObject.name == "Tilemap_SolidBlock")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block (1)")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block (2)")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block (3)")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block (4)")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block (5)")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block (6)")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block (7)")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block (8)")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block (9)")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block (10)")
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.name == "Block (11)")
        {
            Destroy(gameObject);
        }
    }
}
