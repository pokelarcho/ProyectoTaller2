using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public bool tienePistola;
    public float Rango;
    public GameObject Prefab;
    float timer;
    public float MaxTimer;

    Vector3 Dif;
    Vector2 Direccion;
    RaycastHit2D hit;
    RaycastHit2D hit2;
    SpriteRenderer SR;

    void Start()
    {
        Dif = new Vector3(1.5f, 0f, 0f);
        SR = GetComponent<SpriteRenderer>();
        tienePistola = true;
        timer = MaxTimer - 1;
    }

    void Update()
    {
        if (tienePistola)
        {
            RAYO();
            Detect();
        }
    }
    void RAYO()
    {
        hit = Physics2D.Raycast(transform.position + Dif, Vector2.right, Rango);
        hit2 = Physics2D.Raycast(transform.position + (Dif * -1), Vector2.left, Rango);
        Debug.DrawRay(transform.position + Dif, Vector2.right * Rango, Color.green, Time.fixedDeltaTime);
        Debug.DrawRay(transform.position + (Dif * -1), Vector2.left * Rango, Color.blue, Time.fixedDeltaTime);
    }
    void Detect()
    {
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        {
            SR.flipX = true;
            Direccion.x = 1;
            Spawn();
        }
        else if (hit2.collider != null && hit2.collider.gameObject.CompareTag("Player"))
        {
            SR.flipX = false;
            Direccion.x = -1;
            Spawn();
        }
    }
    void Disparo()
    {
        Instantiate(Prefab, transform.position, transform.rotation);
        Prefab.GetComponent<Poff>().direction = Direccion;
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
        if (collision.gameObject.name == "Enemy")
        {
            tienePistola = false;
        }
    }
}
