using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float spawmtime;
    
    private float counter;

    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
         if(counter >= spawmtime){
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            counter = 0;
         }
    }
}
