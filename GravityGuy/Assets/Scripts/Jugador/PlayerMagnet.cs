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
    
    public GameObject Prefab;
    public GameObject Prefab2;
    Vector3 Dife;
    Vector3 DetEnt;
    Vector3 DetEntIzq;
    Vector3 centro;
    RaycastHit2D hit;
    RaycastHit2D hit2;
    Vector2 Direccion;
    Rigidbody2D monster;
    Rigidbody2D monsterspeed;
    Transform monster2;
    Patrulla slime;
    SwitchPoleType stp;
    public AudioClip sfxrepeler;
    public AudioClip sfxatraer;
    public AudioClip sfxcambioPolo;
    public AudioClip sfxcooldown;
    AudioSource ads;
    bool noreprod=false;
    public ParticleSystem poleEffect;
    
    private PlayerMovement pm;

    public bool magnetAction; //verifica si se esta usando la accion
    public bool magnetism;//true es repeler, false atraer
    void Start()
    {
        Dife = new Vector3(1f, 0f);
        DetEnt = new Vector3(2.6f, 0f);
        DetEntIzq = new Vector3(3.1f, 0f);
        centro = new Vector3(0f, 1f);
        direction = 1;
        ads = GetComponent<AudioSource>();
        pm = GetComponent<PlayerMovement>();
        stp = GetComponentInChildren<SwitchPoleType>();

        var emission = poleEffect.emission;
        emission.enabled = false;
    }

   
    void Update()
    {
       
        DetDirection();
        
       
        if (Input.GetKey(KeyCode.S) )
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                ads.PlayOneShot(sfxcambioPolo);
                DetPolo();
            }
        }
        if (Input.GetKey(KeyCode.L) && !CoolActive)
        {
            if (!Input.GetKey(KeyCode.S))
            {
                if (polo)
                {
                    Repel();

                }


                if (!polo)
                {

                    Attract();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.L) && CoolActive) {
                    ads.PlayOneShot(sfxcooldown);

        }
        //si cambia polo mientras atrae, repeler al soltar la tecla
        if (Input.GetKeyUp(KeyCode.L))
        {

            if (magnetAction)
            {
                if (!magnetism)
                {
                    
                    DetPolo();
                    noreprod = false;
                    Repel();
                    hit = new RaycastHit2D();
                    hit2 = new RaycastHit2D();
                }
                var emission = poleEffect.emission;
                emission.enabled = false;
                CoolActive = true;
                Interface.instance.PoleEffector(CoolActive);
                magnetAction = false;
                noreprod = false;
            }
            
        }
        if (CoolActive)
        {
            
            StartCoroutine(RestartCooldown());
        }
    }

    IEnumerator RestartCooldown()
    {
        yield return new WaitForSeconds(CoolDown);
        CoolActive = false;
        Interface.instance.PoleEffector(CoolActive);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (direction == 1)
        {
            Gizmos.DrawWireSphere(transform.position + DetEnt + centro, 1);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position - DetEntIzq + centro, 1);
        }

    }
   /* void CoolDowner()
    {
        timer += Time.deltaTime;
        if (timer >= CoolDown)
        {
            
           
        }
    }*/
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

    void DetPolo()
    {
        //true es positivo
        //false es negativo

       
        if (polo)
        {
            polo = false;
            magnetism = false;
            stp.switchToNegative();
        }
        else if (polo == false)
        {
            polo = true;
            magnetism = true;
            stp.switchToPositive();
        }

    }
   
    void Attract() {
        if (magnetism)
        {
            if (direction == 1)
            {
                hit2 = Physics2D.CircleCast(transform.position + DetEnt + centro, 1, new Vector2(0f, 0f));
                hit = Physics2D.Raycast(transform.position + Dife + centro, Vector2.right, distance);
                Debug.DrawRay(transform.position + Dife + centro, Vector2.right * distance, Color.green, Time.fixedDeltaTime);
            }
            else
            {
                hit2 = Physics2D.CircleCast(transform.position - DetEntIzq + centro, 1, new Vector2(0f, 0f));
                hit = Physics2D.Raycast(transform.position - Dife + centro, Vector2.left, distance);
                Debug.DrawRay(transform.position - Dife + centro, Vector2.left * distance, Color.green, Time.fixedDeltaTime);
            }
        }
        if (hit.collider != null && hit.collider.GetComponent<PoleType>())
        {
            monster2 = hit.collider.GetComponent<Transform>();
            //slime = hit.transform.GetComponent<Patrulla>();

            if (hit.collider.GetComponent<PoleType>().polo == true && !polo)
            {
                magnetAction = true;
                magnetism = false;
                AttractEffect();
                ReproducirSonido(sfxatraer);

                if (Detatrac())
                {
                    monster2.position = transform.position - DetEntIzq + centro;
                }
                else
                {
                    monster2.position = transform.position + DetEnt + centro;
                }
            }
        }

      

        if (direction == 1)
        {
            hit2 = Physics2D.CircleCast(transform.position + DetEnt + centro, 1, new Vector2(0f, 0f));
            hit = Physics2D.Raycast(transform.position + Dife + centro, Vector2.right, distance);
            Debug.DrawRay(transform.position + Dife + centro, Vector2.right * distance, Color.green, Time.fixedDeltaTime);
        }
        else
        {
            hit2 = Physics2D.CircleCast(transform.position - DetEntIzq + centro, 1, new Vector2(0f, 0f));
            hit = Physics2D.Raycast(transform.position - Dife + centro, Vector2.left, distance);
            Debug.DrawRay(transform.position - Dife + centro, Vector2.left * distance, Color.green, Time.fixedDeltaTime);
        }
    }


    void Repel() {

        
        if (direction == 1)
        {
            
            hit = Physics2D.Raycast(transform.position + Dife + centro, Vector2.right, distance);
            Debug.DrawRay(transform.position + Dife + centro, Vector2.right * distance, Color.green, Time.deltaTime);
        }
        else
        {
            
            hit = Physics2D.Raycast(transform.position - Dife + centro, Vector2.left, distance);
            Debug.DrawRay(transform.position - Dife + centro, Vector2.left * distance, Color.green, Time.deltaTime);
        }


        if (hit.collider != null && hit.collider.GetComponent<PoleType>())
        {
            slime = hit.transform.GetComponent<Patrulla>();
            monster = hit.collider.GetComponent<Rigidbody2D>();
            monsterspeed = hit.collider.GetComponent<Rigidbody2D>();

            if (hit.collider.GetComponent<PoleType>().polo == true)
            {
                magnetAction = true;
                magnetism = true;
                RepelEffect();
                ReproducirSonido(sfxrepeler);
                if (slime!=null)
                    slime.setMagnetism();

                if (Detatrac())
                {
                    
                    monster.velocity =  Vector2.right *  atraccion;
                    
                }
                else
                {
                    monster.velocity = Vector2.left * atraccion;
                }
            }

        }
       
    }


    void ReproducirSonido(AudioClip a)
    {
        if (magnetAction)
        {
            if (noreprod == false)
            {
                ads.PlayOneShot(a);
                noreprod = true;

            }
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
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vertigo") )
        {
            centro = new Vector3(0f, 1f);
        }
    }

    void RepelEffect()
    {
        var emission = poleEffect.emission;
        emission.enabled = true;
        /* if (direction==1)
             Direccion.x = 1;
         else
             Direccion.x = -1;

         Instantiate(Prefab, transform.position - Dife + centro, transform.rotation);
         Prefab.GetComponent<MagnetBehaiviour>().direction = Direccion;*/
    }


    void AttractEffect()
    {
        var emission = poleEffect.emission;
        emission.enabled = true;
    }


}
