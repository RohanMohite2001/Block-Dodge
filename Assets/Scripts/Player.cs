using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
                Debug.Log("left clicked");
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed); // -Vector2.left also fine
                Debug.Log("right clicked");
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
