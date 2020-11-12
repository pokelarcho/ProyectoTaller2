using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{

    public int lives;
    private PlayerMovement PM;
    private Vector2 Checkpoint;
    // Start is called before the first frame update
    void Start()
    {
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
            lives--;
           // StopCoroutine(DisableMovement(0));
            StartCoroutine(DisableMovement(.7f));
            //insertar animacion de muerte Trigger
            //
            //
            //

            //Transportar  a Checkpoint
            

            Muerte();


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
        PM.canMove = false;
        yield return new WaitForSeconds(time);
        PM.canMove = true;
        PM.rb.transform.position = Checkpoint;
        PM.vertigo = false;
    }

}
