using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarCollider : MonoBehaviour
{

    public GameObject Hangar;
    HangarDoor hd;
    // Start is called before the first frame update
    void Start()
    {
        hd = Hangar.GetComponent<HangarDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            hd.anim1 = true;
            hd.AbrirPuerta();


        }
    }
}
