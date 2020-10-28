using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using PowerTools;


public class PlayerMovement : MonoBehaviour
{
    

    private Collision coll;
    [HideInInspector]
    public Rigidbody2D rb;
    private AnimationScript anim;
    public SpriteRenderer sp;



    [Space]
    [Header("Stats")]
    public float speed = 10;
    public float jumpForce = 50;
    public float slideSpeed = 5;
    public float wallJumpLerp = 10;
    public float dashSpeed = 20;


    [Space]
    [Header("Booleanos")]
    public bool canMove;
    public bool wallGrab;
    public bool wallJumped;
    public bool wallSlide;
    public bool isDashing;
    public bool grounded;
    public bool vertigo;
    
    
    [Space]

    private bool groundTouch;
    private bool hasDashed;

    public int side = 1;


    
    [Space]
    [Header("Polish")]
    public ParticleSystem dashParticle;
    public ParticleSystem jumpParticle;
    

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<AnimationScript>();
        sp = GetComponentInChildren<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);

        anim.SetHorizontalMovement(x, y, rb.velocity.y, vertigo);

        if (grounded && !isDashing)
        {
            wallJumped = false;
            GetComponent<BetterJumping>().enabled = true;
        }
        

        if (Input.GetButtonDown("Jump"))
        {
            //anim.SetTrigger("jump");

            if (grounded)
                Jump(Vector2.up);
            }


        //DASH
        if (Input.GetKeyDown(KeyCode.J) && !hasDashed)
        {
            if (xRaw != 0 || yRaw != 0)
                Dash(xRaw, yRaw);
        }

        if (grounded && !groundTouch)
        {
            GroundTouch();
            groundTouch = true;
        }

        if (!grounded && groundTouch)
        {
            groundTouch = false;
        }




       if (x > 0)
         {
             side = 1;
             anim.Flip(side);
         }
         if (x < 0)
         {
             side = -1;
             anim.Flip(side);
         }
        


        if (vertigo == true)
        {
            
            rb.gravityScale = -20;
            GetComponent<BetterJumping>().enabled = false;
            //transform.Rotate(new Vector3(180, 0, 0));
            sp.flipY = true;
            
            /* if (Cam)
             {
                 CamPlay.GetComponent<Transform>().position = new Vector3(Camo.x, Camo.y, 10f);
             }*/
        }
        else
        {
            
            rb.gravityScale = 20;
            GetComponent<BetterJumping>().enabled = false;
            sp.flipY = false;

            /* if (Cam)
             {
                 CamPlay.GetComponent<Transform>().position = new Vector3(Camo.x, Camo.y, -10f);
             }
            */
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            isDashing = true;
            if (vertigo)
            {
                
                 vertigo = false;
                
            }
            else
            {
                
                vertigo = true;

            }

        }

        if (collision.gameObject.CompareTag("Vertigo"))
        {


            vertigo = true;


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            isDashing = false;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;

        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Vertigo"))
        {
            vertigo = false;
        }
    }


    private void Jump(Vector2 dir)
    {
        
         ParticleSystem particle = jumpParticle;

        if (vertigo)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += dir * jumpForce * -1;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += dir * jumpForce;
        }

       particle.Play();
    }

    private void Walk(Vector2 dir)
    {
        if (!canMove)
            return;

        if (wallGrab)
            return;

        if (!wallJumped)
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }

        {
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
        }

    }





    void GroundTouch()
    {
        hasDashed = false;
        isDashing = false;

       side = anim.sr.flipX ? -1 : 1;
     
        jumpParticle.Play();
    }




    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    private void Dash(float x, float y)
    {
      Camera.main.transform.DOComplete();
      Camera.main.transform.DOShakePosition(.2f, .5f, 14, 90, false, true);
        //FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));
     
        hasDashed = true;

        // anim.SetTrigger("dash");
        
        StartCoroutine(DisableMovement(.2f));
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x, y);

        rb.velocity += dir.normalized * dashSpeed;
        StartCoroutine(DashWait());
    }

    void RigidbodyDrag(float x)
    {
        rb.drag = x;
    }

    IEnumerator DashWait()
    {
       FindObjectOfType<GhostTrail>().ShowGhost();
        StartCoroutine(GroundDash());
        DOVirtual.Float(14, 0, .8f, RigidbodyDrag);

        dashParticle.Play();
       /* if (coll.onVertigo)
            rb.gravityScale = -1;
        else
            rb.gravityScale = 1;
        */
        GetComponent<BetterJumping>().enabled = false;
        
        isDashing = true;

        yield return new WaitForSeconds(.3f);

        dashParticle.Stop();
        /*if(coll.onVertigo)
            rb.gravityScale = -20;
        else
            rb.gravityScale = 20;
        */
        GetComponent<BetterJumping>().enabled = true;
        
        isDashing = false;
    }


    IEnumerator GroundDash()
    {
        yield return new WaitForSeconds(.15f);
        if (grounded)
            hasDashed = false;
    }



    


    
}
