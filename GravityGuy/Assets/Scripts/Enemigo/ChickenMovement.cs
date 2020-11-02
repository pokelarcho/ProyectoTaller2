using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    RaycastHit2D hit;


    void Start()
    {
        
    }

    void Update()
         {
                 hit = Physics2D.Raycast(transform.position, Vector2.left, 10);
                    Debug.DrawRay(transform.position, Vector2.left * 10, Color.green, Time.fixedDeltaTime);
        if (hit.collider.tag == "Player")
        {
            GetComponent<Rigidbody2D>().velocity = speed * Vector2.left;
        }

    }

   
       

    






}