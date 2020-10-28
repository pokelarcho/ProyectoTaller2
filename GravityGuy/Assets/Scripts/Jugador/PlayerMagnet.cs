using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{

    public bool polo;
    public int distance;
    public float atraccion;
    public int direction;
    Vector3 Dife;
    RaycastHit2D hit;
    Rigidbody2D monster;

    void Start()
    {
        Dife = new Vector3(3f, 0f, 0f);
        direction = 1;
    }

    void Update()
    {
        DetDirection();
        DetMag();
        DetPolo();
        Magnetismo();
    }
    // 1 es derecha
    // -1 es izquierda
    void DetDirection()
    {
        float x = Input.GetAxis("Horizontal");
        if (x > 0)
        {
            direction = 1;
        }
        else if (x < 0)
        {
            direction = -1;
        }
    }
    void DetMag()
    {
        if (direction == 1)
        {
            hit = Physics2D.Raycast(transform.position + Dife, Vector2.right, distance);
            Debug.DrawRay(transform.position + Dife, Vector2.right * distance, Color.green, Time.fixedDeltaTime);
        }
        else if (direction == -1)
        {
            hit = Physics2D.Raycast(transform.position - Dife, Vector2.left, distance);
            Debug.DrawRay(transform.position - Dife, Vector2.left * distance, Color.green, Time.fixedDeltaTime);
        }
    }
    //true es positivo
    //false es negativo
    void DetPolo()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (polo)
            {
                polo = false;
            }
            else if (polo == false)
            {
                polo = true;
            }
        }
    }
    void Magnetismo()
    {
        if (Input.GetKeyDown(KeyCode.L)) {
            if (hit.collider != null && hit.collider.tag == "Enemy") { }
            {
                monster = hit.transform.GetComponent<Rigidbody2D>();
                if (direction == 1 && polo || direction == -1 && polo == false)
                {
                    monster.velocity = new Vector2(atraccion, 0f);
                }
                if (direction == -1 && polo || direction == 1 && polo == false)
                {
                    monster.velocity = new Vector2(atraccion * -1, 0f);
                }
            }
        }
    }
}
