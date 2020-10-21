using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01 : MonoBehaviour
{
    public Rigidbody2D rb2;
    public GameObject CamPlay;

    bool jump;
    bool UpDown;

    bool Dasher;
    public float DashSpeed;

    public bool Cam;
    Vector3 Camo;

    public float JumpForce;
    public float speed;
    public int life;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        Camo = CamPlay.GetComponent<Transform>().position;
    }
    void Update()
    {
        Life();
    }
    void Life()
    {
        if (life <= 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            Gravity();
            Jump();
            Move();
        }
    }
    void Gravity()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            if (Cam)
            {
                CamPlay.transform.Rotate(new Vector3(180f, 0f, 0f));
            }
            if (UpDown == false)
            {
                UpDown = true;
            }
            else if (UpDown)
            {
                UpDown = false;
            }
        }
        if (UpDown)
        {
            rb2.gravityScale = -5;
            GetComponent<SpriteRenderer>().flipY = true;
            if (Cam)
            {
                CamPlay.GetComponent<Transform>().position = new Vector3(Camo.x, Camo.y, 10f);
            }
        }
        else
        {
            rb2.gravityScale = 5;
            GetComponent<SpriteRenderer>().flipY = false;
            if (Cam)
            {
                CamPlay.GetComponent<Transform>().position = new Vector3(Camo.x, Camo.y, -10f);
            }
        }
    }
    void Jump ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump)
        {
            if (UpDown)
            {
                rb2.AddForce(new Vector2(0, JumpForce * -1));
            }
            else
            {
                rb2.AddForce(new Vector2(0, JumpForce));
            }
        }
    }
    void Move () 
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (h < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        rb2.velocity = new Vector2(h * speed, rb2.velocity.y);
        if (Input.GetKeyDown(KeyCode.G) && Dasher)
        {
            Dash();
        }
    }
    void Dash()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rb2.velocity = new Vector2(h * DashSpeed, v * DashSpeed);
        Dasher = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = true;
            
        }
        if (collision.gameObject.CompareTag("tramp"))
        {
            life = 0;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }
}
