using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerTools;

public class ChickenMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float Rango;

    Vector3 Dif;
    RaycastHit2D hit;
    RaycastHit2D hit2;
    SpriteAnim CompAnim;
    public AnimationClip animdestruct;
    public AnimationClip animwalk;
    SpriteRenderer SR;
    Rigidbody2D Rb2D;
    bool anim1=false, anim2=false;
    public AudioClip Caminar;
    public AudioClip Explotar;
    AudioSource ads;

    void Start()
    {
        Dif = new Vector3(1.5f, 0f, 0f);
        SR = GetComponent<SpriteRenderer>();
        Rb2D = GetComponent<Rigidbody2D>();
        CompAnim = GetComponent<SpriteAnim>();
        ads = GetComponent<AudioSource>();
    }

    void Update()
    {
        RAYO();
        Detect();

        if (anim1) {
            if (anim2 == false)
            {
                CompAnim.Play(animwalk);
                ads.PlayOneShot(Caminar);
                anim2 = true;
            }
        }
    }
    void RAYO()
    {
        hit = Physics2D.Raycast(transform.position + Dif, Vector2.right, Rango);
        hit2 = Physics2D.Raycast(transform.position + (Dif * -1), Vector2.left, Rango);
        Debug.DrawRay(transform.position + Dif, Vector2.right * Rango, Color.green, Time.fixedDeltaTime);
        Debug.DrawRay(transform.position + (Dif * -1), Vector2.left * Rango, Color.blue, Time.fixedDeltaTime);
    }
    void Detect()
    {
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        {
            SR.flipX = true;
            Rb2D.velocity = new Vector2(speed, Rb2D.velocity.y);
            anim1 = true;
        }
        else if (hit2.collider != null && hit2.collider.gameObject.CompareTag("Player"))
        {
            SR.flipX = false;
            Rb2D.velocity = new Vector2(speed * -1, Rb2D.velocity.y);
            anim1 = true;
            
        }
       

    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            CompAnim.Play(animdestruct);
            ads.PlayOneShot(Explotar);
        }
    }

    public void Destroy()
    {
        
        Destroy(this.gameObject);
    }
}