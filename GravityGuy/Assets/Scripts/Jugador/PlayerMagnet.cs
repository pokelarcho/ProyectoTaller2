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
    Transform monster;

    void Start()
    {
        Dife = new Vector3(1f, 0f, 0f);
        direction = 1;
    }

    void Update()
    {
        DetDirection();
        DetMag();
        if (Input.GetKey(KeyCode.L))
        {
            Magnetismo();
            
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            DetPolo();
        }
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
        if (polo)
        {
            polo = false;
        }
        else if (polo == false)
        {
            polo = true;
        }
    }
    void Magnetismo()
    {
        if (hit.collider != null && hit.collider.GetComponent<PoleType>())
        {
            if (hit.collider.GetComponent<PoleType>().polo == true)
            {
                monster = hit.transform.GetComponent<Transform>();
                if (Detatrac())
                {
                    monster.position = new Vector2(monster.position.x + atraccion, monster.position.y);
                }
                else
                {
                    monster.position = new Vector2(monster.position.x + (atraccion * -1), monster.position.y);
                }
            }
            else if (hit.collider.GetComponent<PoleType>().polo == false)
            {
                monster = hit.transform.GetComponent<Transform>();
                if (Detatrac())
                {
                    monster.position = new Vector2(monster.position.x + atraccion, monster.position.y);
                }
                else
                {
                    monster.position = new Vector2(monster.position.x + (atraccion * -1), monster.position.y);
                }
            }
        }
    }
    bool Detatrac()
    {
        return direction == 1 && polo || direction == -1 && polo == false;
    }

}
