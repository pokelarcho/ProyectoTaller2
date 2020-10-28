using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerTools;

public class Patrulla : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sp;
    public AnimationClip animRun;
    public AnimationClip animIdle;
    public float speed;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("1"))
        {
            speed *= -1;
            transform.Rotate(new Vector3(0, 180, 0));
        }

        if (collision.gameObject.CompareTag("2"))
        {
            speed *= -1;
            transform.Rotate(new Vector3(0,180, 0));
        }
        if (collision.gameObject.CompareTag("Vertigo"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 20 * -1;
            transform.Rotate(new Vector3(180, 0, 0));
            //GetComponent<SpriteRenderer>().flipY = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vertigo"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 20;

            transform.Rotate(new Vector3(180, 0, 0));
            
        }
    }

}
