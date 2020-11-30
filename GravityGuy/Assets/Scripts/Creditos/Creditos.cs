using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Creditos : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;
  
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Move();
    }

    void Move()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
    }
}
