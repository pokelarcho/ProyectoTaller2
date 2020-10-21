using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public Vector2 jumpForce;
    public bool grounded;
    public int lives;
    public int score;
    public GameObject counterTextGameObject;
    public GameObject counterTextGameObject2;
    public bool direccion;

    private int direction;

    public float dashSpeed;
    private float dashTime;
    public float startDahsTime;

    


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        mirar();
        Jump();
        Death();
        Dash();
        
        
    }



    void Move()
    {
        if (Input.GetKey(KeyCode.A))
     {
        transform.position += Vector3.left * speed * Time.deltaTime;
     }
        if (Input.GetKey(KeyCode.D))
     {
       transform.position += Vector3.right * speed * Time.deltaTime;
     }
    }


    void Death()
    {
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }


    }


    void Dash(){
        if(direction == 0){
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                direction = 1;
            }else if(Input.GetKeyDown(KeyCode.RightArrow)){
                direction = 2;
            }else if(Input.GetKeyDown(KeyCode.UpArrow)){
                direction = 3;
            }else if(Input.GetKeyDown(KeyCode.DownArrow)){
                direction = 4;
            }
        }else{
            if(dashTime <= 0){
              direction = 0;
              dashTime = startDahsTime;
              rb2d.velocity = Vector2.zero;
            }else{
                dashTime -= Time.deltaTime;

                if(direction == 1){
                    rb2d.velocity = Vector2.left * dashSpeed; 
                }else if(direction == 2){
                    rb2d.velocity = Vector2.right * dashSpeed;
                }else if(direction == 3){
                    rb2d.velocity = Vector2.up * dashSpeed;
                }else if(direction == 4){
                    rb2d.velocity = Vector2.down * dashSpeed;
                }
            }
        }
    }




    void Jump()
    {
        if (grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.AddForce(jumpForce);
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Piso")){
            grounded = true;}

        if (collision.gameObject.CompareTag("Gira")){
            GetComponent<Rigidbody2D>().gravityScale = -2f;
        }

         if (collision.gameObject.CompareTag("Gira")){
            GetComponent<SpriteRenderer>().color = Color.blue;
        }

        if (collision.gameObject.CompareTag("Baja")){
            GetComponent<Rigidbody2D>().gravityScale = 2f;
        }

        if (collision.gameObject.CompareTag("Baja"))
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        
    }

     private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso")){
            grounded = false;}
        
        
    }



    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Bala")){
            GetComponent<Rigidbody2D>().gravityScale = -2f;
        }
    }



    private void mirar()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            direccion = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direccion = true;
        }
    }

    



}
