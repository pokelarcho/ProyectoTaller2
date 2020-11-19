using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{

    public int lives;
    private PlayerMovement PM;
    private Vector2 Checkpoint;
    public bool isDeath;
    public bool invencible= false;
    public float timeInvencible;
   // private AnimationScript anim;
    // Start is called before the first frame update
    void Start()
    {
        isDeath = false;
        PM = GetComponent<PlayerMovement>();

        //creacion de CheckPoint
        Checkpoint = transform.position;


    }

    // Update is called once per frame
    void Update()
    {




    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!invencible)
            {
                PM.speed = 0;

                isDeath = true;
                invencible = true;
                lives--;
                PM.anim.SetTrigger("death");
                // StopCoroutine(DisableMovement(0));
                StartCoroutine(DisableMovement(.7f));
                
                FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));
                

                //Transportar  a Checkpoint
                StartCoroutine(Invencibilidad(5f));

                Muerte();
            }

        }


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!invencible)
            {
                PM.speed = 0;
                
                isDeath = true;
                invencible = true;
                lives--;
                PM.anim.SetTrigger("death");
                // StopCoroutine(DisableMovement(0));
                StartCoroutine(DisableMovement(.7f));

                FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));


                //Transportar  a Checkpoint
                StartCoroutine(Invencibilidad(5f));

                Muerte();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("CheckPoint"))
            {
                Checkpoint = transform.position;
            }

        if (collision.gameObject.CompareTag("Lives"))
        {
            lives++;



        }
    }



    
    private void Muerte()
    {
        
        //Redireccion de pantalla
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    IEnumerator DisableMovement(float time)
    {
        
        
        PM.grounded = true;
        PM.anim.SetHorizontalMovement(0, 0, 0,0, true);
        PM.isDashing = true;
        yield return new WaitForSeconds(time);
        PM.rb.transform.position = Checkpoint;
        
        StartCoroutine(Revivir(.8f));

    }
        IEnumerator Revivir(float time)
    {
        PM.anim.SetTrigger("revive");
        yield return new WaitForSeconds(.8f);
        PM.isDashing = false;

        PM.vertigo = false;
        isDeath = false;
        PM.canMove = true;
        PM.speed = 15;
        
    }
        IEnumerator Invencibilidad(float time)
    {
        PM.sp.color = Color.gray;
        yield return new WaitForSeconds(time);
        invencible = false;
        PM.sp.color = Color.white;

    }

}
