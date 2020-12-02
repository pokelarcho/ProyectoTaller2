using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poff : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;
    public Vector2 direction;

     float timer;
    public float maxTimer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Timer();
    }
    void Timer()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            Destroy(gameObject);
        }
    }
    void Move()
    {
        rb2d.velocity = direction * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
