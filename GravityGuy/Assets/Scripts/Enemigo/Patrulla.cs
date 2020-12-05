using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla : MonoBehaviour
{
    public float speed;
    

    Vector3 Dife;
    Vector3 centro;

    Rigidbody2D rb2d;
    RaycastHit2D hit;
    SpriteRenderer SR;
    public bool isMagneted = false;

    void Start()
    {
        Dife = new Vector3(1f, 0f, 0f);
        centro = new Vector3(0f, 0.1f, 0f);
        rb2d = GetComponent<Rigidbody2D>();
        
        SR = GetComponentInChildren<SpriteRenderer>();
        
    }
    void Update()
    {


        //TESTEAR BIEN
        if (!isMagneted)
        {
            Move();
        }
        else
        {
            speed = 0;
            //StopCoroutine(RestartMovement());
            StartCoroutine(RestartMovement());
        }
        Rayo();
        Cambio();
       Animar();
    }

    IEnumerator RestartMovement()
    {
        yield return new WaitForSeconds(1f);
        isMagneted = false;
        speed = 5;
    }
    void Rayo()
    {
        if (speed > 0)
        {
            hit = Physics2D.Raycast(transform.position + Dife + centro, Vector2.right, 2);
            Debug.DrawRay(transform.position + Dife + centro, Vector2.right * 2, Color.blue);
        }
        else if (speed < 0)
        {
            hit = Physics2D.Raycast(transform.position - Dife + centro, Vector2.left, 2);
            Debug.DrawRay(transform.position - Dife + centro, Vector2.left * 2, Color.green);
        }
    }

    public void setMagnetism() {
        isMagneted = true;
    }

    void Move()
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }
   void Animar()
    {
        if (speed != 0)
        {
           
            if (speed > 0)
            {
                SR.flipX = true;
            }
            else if (speed < 0)
            {
                SR.flipX = false;
            }
        }
        
    }
    void Cambio()
    {
        if (hit.collider != null && hit.collider.tag != "Player")
        {
            speed *= -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float scalay = transform.GetScaleY();

        if (collision.gameObject.CompareTag("Vertigo"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 15 * -1;
            transform.SetScaleY(-1 * Mathf.Abs(scalay));
            //SR.flipY = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        float scalay = transform.GetScaleY();
        if (collision.gameObject.CompareTag("Vertigo"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 15;
            transform.SetScaleY(1 * Mathf.Abs(scalay));
            //SR.flipY = false;
        }
    }
}
