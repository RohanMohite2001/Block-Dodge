using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    public int maxHealth = 100;
    private int health;
    public event EventHandler<HealthChangedEventArgs> OnHealthChanged;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            health -= 10;
            OnHealthChanged?.Invoke(this, new HealthChangedEventArgs
            {
                Health = health,
                MaxHealth = maxHealth
            });
        }
    }

    public class HealthChangedEventArgs : EventArgs 
    {
        public float Health;
        public float MaxHealth;
    }
}
