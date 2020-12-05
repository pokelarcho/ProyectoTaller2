using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOshoot : MonoBehaviour
{

    public float spawmtime;
    float timer;

    public GameObject bulletPrefab;
    public GameObject Player;
    public float BulletSpeed;
    GameObject BS;

    Vector2 dir;

    private void Start()
    {
        dir = (transform.position - Player.transform.position).normalized;
        //BS.GetComponent<Rigidbody2D>().velocity = BulletSpeed * dir;
    }
    void Update()
    {
        
    }
   public void Spawner()
    {

        float dist = Vector3.Distance(Player.transform.position, transform.position);

        if(dist < 26)
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
}


