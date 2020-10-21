using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float velocidad;
    public float spawmtime;
    public GameObject spawner;
    public GameObject bala;
    private float counter;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
         if(counter > spawmtime){
           GameObject bullet = (GameObject)Instantiate(bala, spawner.transform, true);
           bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, bullet.GetComponent<Rigidbody2D>().velocity.y);
           counter = 3;
         }
    }
}
