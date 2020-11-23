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
    Vector3 Dife2;
    Vector3 DetEnt;
    Vector3 DetEnt2;
    RaycastHit2D hit;
    RaycastHit2D hit2;
    Transform monster;
    Patrulla slime;
    private PlayerMovement pm;
    public bool magnetAction; //verifica si esta atrayendo
    public bool magnetism;//true es repeler, false atraer

    void Start()
    {
        Dife = new Vector3(2f, 1f, 0f);
        Dife2 = new Vector3(2f, -1f, 0f);
        DetEnt = new Vector3(4f, 1.5f, 0f);
        DetEnt2 = new Vector3(-4f, 1.5f, 0f);
        direction = 1;
        pm = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        DetDirection();
        if (Input.GetKey(KeyCode.L))
        {
            Magnetismo();
            DetMag();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            DetPolo();
        }

        if (Input.GetKeyUp(KeyCode.L)) {
            if (magnetAction == true && magnetism == false)
            {
                DetPolo();
                Magnetismo();
                
            }
            magnetAction = false;
        }
    }
    // 1 es derecha
    // -1 es izquierda
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (direction == 1)
        {
            Gizmos.DrawSphere(transform.position + DetEnt, 1);
        }
        else
        {
            Gizmos.DrawSphere(transform.position + DetEnt2, 1);
        }

    }
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
            hit2 = Physics2D.CircleCast(transform.position + DetEnt, 1, new Vector2(0f, 0f));
            hit = Physics2D.Raycast(transform.position + Dife, Vector2.right, distance);
            Debug.DrawRay(transform.position + Dife, Vector2.right * distance, Color.green, Time.fixedDeltaTime);

        }
        else
        {
            hit2 = Physics2D.CircleCast(transform.position + (DetEnt2), 1, new Vector2(0f, 0f));
            hit = Physics2D.Raycast(transform.position - Dife2, Vector2.left, distance);
            Debug.DrawRay(transform.position - Dife2, Vector2.left * distance, Color.green, Time.fixedDeltaTime);
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
        if (hit2.collider != null && hit2.collider.GetComponent<PoleType>())
        {
            monster = hit2.transform.GetComponent<Transform>();
            slime = hit2.transform.GetComponent<Patrulla>();
            if (hit2.collider.GetComponent<PoleType>().polo == true && polo == true)
            {

                
                magnetAction = true;
                magnetism = false;
                slime.isMagneted = true;

                if (Detatrac())
                {
                    monster.position = transform.position + new Vector3(4f, 1f, 0f);
                    
                }
                else
                {
                    monster.position = transform.position + new Vector3(-4f, 1f, 0f);
                }


            }
            else if (hit2.collider.GetComponent<PoleType>().polo == false && polo == false)
            {
                
                magnetAction = true;
                magnetism = false;
                slime.isMagneted = true;
                if (Detatrac())
                {
                    monster.position = transform.position + new Vector3(-4f, 1f, 0f);
                }
                else
                {
                    monster.position = transform.position + new Vector3(4f, 1f, 0f);
                }
            }
        }
        if (hit.collider != null && hit.collider.GetComponent<PoleType>())
        {
            slime = hit.transform.GetComponent<Patrulla>();
            monster = hit.transform.GetComponent<Transform>();
            if (hit.collider.GetComponent<PoleType>().polo == true && polo == false)
            {
                
                magnetAction = true;
                magnetism = true;
                slime.isMagneted = true;

                if (Detatrac())
                {
                    

                    monster.position = new Vector2(monster.position.x + (atraccion*-1), monster.position.y);
                }
                else
                {
                   
                    monster.position = new Vector2(monster.position.x + (atraccion), monster.position.y);
                }
            }
            else if (hit.collider.GetComponent<PoleType>().polo == false && polo == true)
            {
              
                magnetAction = true;
                magnetism = true;
                slime.isMagneted = true;
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
