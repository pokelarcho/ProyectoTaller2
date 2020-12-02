using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOshoot : MonoBehaviour
{

    public float spawmtime;
    float timer;

    public float radio;


    public GameObject bulletPrefab;
    public GameObject Player;
    public float BulletSpeed;
    GameObject BS;

    Vector2 dir;
    RaycastHit2D hit;

    private void Start()
    {
        dir = (transform.position - Player.transform.position).normalized;
    }
    void FixedUpdate()
    {
        Rayo();
    }
    void Spawner()
    {
        timer += Time.deltaTime;
        if (timer >= spawmtime)
        {
            BS = Instantiate(bulletPrefab, transform.position, transform.rotation);
            timer = 0;
            PlayerPosicion();
        }
    }
    void PlayerPosicion()
    {
        dir = (Player.transform.position - transform.position).normalized;
        BS.GetComponent<Rigidbody2D>().velocity = BulletSpeed * dir;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, radio);
    }
    void Rayo()
    {
        hit = Physics2D.CircleCast(transform.position, radio, new Vector2(0f, 0f));
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Spawner();
        }
    }
}


