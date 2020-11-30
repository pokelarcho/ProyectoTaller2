using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{

    public bool polo;
    public int distance;
    public float atraccion;
    public int direction;

    public bool CoolActive;
    public float CoolDown;
    float timer;

    Vector3 Dife;
    Vector3 DetEnt;
    Vector3 centro;
    RaycastHit2D hit;
    RaycastHit2D hit2;

    Rigidbody2D monster;
    Rigidbody2D monsterspeed;
    Transform monster2;
    Patrulla slime;

    private PlayerMovement pm;

    public bool magnetAction; //verifica si esta atrayendo
    public bool magnetism;//true es repeler, false atraer
    void Start()
    {
        Dife = new Vector3(4f, 0f);
        DetEnt = new Vector3(3f, 0f);
        centro = new Vector3(0f, 1f);
        direction = 1;
        pm = GetComponent<PlayerMovement>();
    }
    void FixedUpdate()
    {
        DetDirection();

        if (Input.GetKey(KeyCode.L) && !CoolActive)
        {
            Magnetismo();
            DetMag();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            DetPolo();
        }

        //si cambia polo mientras atrae, repeler al soltar la tecla
        if (Input.GetKeyUp(KeyCode.L))
        {
            if (magnetAction && !magnetism)
            {
                CoolActive = true;
                DetPolo();
                Magnetismo();
            }
            magnetAction = false;
        }
        if (CoolActive)
        {
            CoolDowner();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (direction == 1)
        {
            Gizmos.DrawSphere(transform.position + DetEnt + centro, 1);
        }
        else
        {
            Gizmos.DrawSphere(transform.position - DetEnt + centro, 1);
        }

    }
    void CoolDowner()
    {
        timer += Time.deltaTime;
        if (timer >= CoolDown)
        {
            CoolActive = false;
        }
    }
    void DetDirection()
    {
        // 1 es derecha
        // -1 es izquierda
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
            hit2 = Physics2D.CircleCast(transform.position + DetEnt + centro, 1, new Vector2(0f, 0f));
            hit = Physics2D.Raycast(transform.position + Dife + centro, Vector2.right, distance);
            Debug.DrawRay(transform.position + Dife + centro, Vector2.right * distance, Color.green, Time.fixedDeltaTime);
        }
        else
        {
            hit2 = Physics2D.CircleCast(transform.position - DetEnt + centro, 1, new Vector2(0f, 0f));
            hit = Physics2D.Raycast(transform.position - Dife + centro, Vector2.left, distance);
            Debug.DrawRay(transform.position - Dife + centro, Vector2.left * distance, Color.green, Time.fixedDeltaTime);
        }
    }
    void DetPolo()
    {
        //true es positivo
        //false es negativo
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
            monster2 = hit2.collider.GetComponent<Transform>();
            //slime = hit2.transform.GetComponent<Patrulla>();
            if (hit2.collider.GetComponent<PoleType>().polo == true && polo)
            {
                magnetAction = true;
                magnetism = false;
                //slime.isMagneted = true;

                if (Detatrac())
                {
                    monster2.position = transform.position + DetEnt + centro;
                }
                else
                {
                    monster2.position = transform.position - DetEnt + centro;
                }
            }
            else if (hit2.collider.GetComponent<PoleType>().polo == false && !polo)
            {
                magnetAction = true;
                magnetism = false;
               //slime.isMagneted = true;
                if (Detatrac())
                {
                    monster2.position = transform.position - DetEnt + centro;
                }
                else
                {
                    monster2.position = transform.position + DetEnt + centro;
                }
            }
        }
        else if (hit.collider != null && hit.collider.GetComponent<PoleType>())
        {
            //slime = hit.transform.GetComponent<Patrulla>();
            monster = hit.collider.GetComponent<Rigidbody2D>();
            monsterspeed = hit.collider.GetComponent<Rigidbody2D>();

            if (hit.collider.GetComponent<PoleType>().polo == false)
            {
                magnetAction = true;
                magnetism = true;
               // slime.isMagneted = true;

                if (Detatrac())
                {
                    monster.velocity = Vector2.right * atraccion;
                }
                else
                {
                    monster.velocity = Vector2.left * atraccion;
                }
            }
            else if (hit.collider.GetComponent<PoleType>().polo == true)
            {
                magnetAction = true;
                magnetism = true;
                //slime.isMagneted = true;
                if (Detatrac())
                {
                    monster.velocity = Vector2.left * atraccion;
                }
                else
                {
                    monster.velocity = Vector2.right * atraccion;
                }
            }
        }
        else if (hit2.collider != null && hit.collider != null)
        {
            magnetAction = false;
            monster.velocity = monsterspeed.velocity;
        }
    }
    bool Detatrac()
    {
        return direction == 1 && polo || direction == -1 && !polo;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vertigo") )
        {
            centro = new Vector3(0f, -1f);
        }

        if (collision.gameObject.CompareTag("Bala"))
        {
            if (pm.vertigo)
            {
               
                centro = new Vector3(0f, -1f);

            }
            else
            {

                centro = new Vector3(0f, 1f);

            }
        }    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vertigo") )
        {
            centro = new Vector3(0f, 1f);
        }
    }
}
