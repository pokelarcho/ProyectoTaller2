using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public bool tienePistola;
    public float Rango;
    public GameObject Prefab;
    public GameObject Arma;
    float timer;
    public float MaxTimer;
    public GameObject Player;
    public AudioClip AC;
    AudioSource AS;
    Vector3 Centro;
    Vector3 Dif;
    Vector2 Direccion;
    RaycastHit2D hit;
    RaycastHit2D hit2;
    SpriteRenderer SR;
    SpriteRenderer SR_Arma;

    void Start()
    {
        AS = GetComponent<AudioSource>();
        SR_Arma = Arma.GetComponent<SpriteRenderer>();
        Centro = new Vector3(0, 1);
        Dif = new Vector3(1.5f, 0f, 0f);
        SR = GetComponent<SpriteRenderer>();
        tienePistola = true;
        timer = MaxTimer - 1;
    }

    void Update()
    {
        if (tienePistola)
        {
            Detect();
        }
    }
    void Detect()
    {
        float dist = Vector3.Distance(Player.transform.position, transform.position);

        if (dist < Rango)
        {
            if (transform.position.x > Player.transform.position.x)
            {
                SR_Arma.flipX = true;
                SR.flipX = true;
                Direccion.x = -1;
                Spawn();
            }
           else if (transform.position.x < Player.transform.position.x)
            {
                SR_Arma.flipX = false;
                SR.flipX = false;
                Direccion.x = 1;
                Spawn();
            }
        }
    }
    void Disparo()
    {
        AS.PlayOneShot(AC);
        Prefab.GetComponent<Poff>().direction = Direccion;
        Instantiate(Prefab, transform.position + Centro, transform.rotation);
    }
    void Spawn()
    {
        timer += Time.deltaTime;
        if (timer >= MaxTimer)
        {
            Disparo();
            timer = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arma"))
        {
            tienePistola = false;
        }
        if (collision.gameObject.CompareTag("Vertigo"))
        {
            Centro = new Vector3(0, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vertigo"))
        {
            Centro = new Vector3(0, -1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arma"))
        {
            tienePistola = false;
        }
    }
}
