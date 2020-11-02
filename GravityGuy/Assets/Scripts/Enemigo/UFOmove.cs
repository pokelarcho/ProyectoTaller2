using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOmove : MonoBehaviour
{
    public GameObject goPoint1;
    public GameObject goPoint2;
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = speed * Vector2.right;
    }
    void FixedUpdate()
    {


        //goPoint1
        RaycastHit2D hit1 = Physics2D.Raycast(goPoint1.transform.position, Vector2.up, 4);
        Debug.DrawRay(goPoint1.transform.position, Vector3.up * 4, Color.green, Time.fixedDeltaTime);

        //goPoint2
        RaycastHit2D hit2 = Physics2D.Raycast(goPoint2.transform.position, Vector2.up, 4);
        Debug.DrawRay(goPoint2.transform.position, Vector3.up * 4, Color.green, Time.fixedDeltaTime);

        if (hit1.collider == null)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Rigidbody2D>().velocity = speed * Vector2.right;
        }
        if (hit2.collider == null)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Rigidbody2D>().velocity = speed * Vector2.left;
        }
    }
}

