using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerTools;

public class Patrulla : MonoBehaviour
{
    public float speed;
    public AnimationClip animRun;
    public AnimationClip animIdle;

    Vector3 Dife;
    Vector3 centro;

    Rigidbody2D rb2d;
    RaycastHit2D hit;
    SpriteRenderer SR;
    SpriteAnim CompAnim;
    public bool isMagneted=false;

    void Start()
    {
        Dife = new Vector3(1f, 0f, 0f);
        centro = new Vector3(0f, 0.5f, 0f);
        rb2d = GetComponent<Rigidbody2D>();
        CompAnim = GetComponent<SpriteAnim>();
        SR = GetComponent<SpriteRenderer>();
        CompAnim.Play(animIdle);
    }
    void Update()
    {
        if (isMagneted==false)
        {
           
            Move();
            

        }
        else
        {
            speed = 0;
            StartCoroutine(RestartMovement());
            
        }

        Rayo();
        Cambio();
        Animar();


    }

    IEnumerator RestartMovement() {
        yield return new WaitForSeconds(3f);
        isMagneted = false;
        speed = 15;
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
    void Move()
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }
    void Animar()
    {
        if (speed != 0)
        {
            if (CompAnim.Clip != animRun)
            {
                CompAnim.Play(animRun);
            }
            else if (speed > 0)
            {
                SR.flipX = true;
            }
            else if (speed < 0)
            {
                SR.flipX = false;
            }
        }
        else
        {
            if (CompAnim.Clip != animIdle)
            {
                CompAnim.Play(animIdle);
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
        if (collision.gameObject.CompareTag("Vertigo"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 20 * -1;
            SR.flipY = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vertigo"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 20;
            SR.flipY = false;
        }
    }
}
