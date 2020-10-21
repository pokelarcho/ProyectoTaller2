using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{

    public bool polo;
    public int distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = 5;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, distance);
            Debug.DrawRay(transform.position, Vector3.down * 2, Color.green, Time.fixedDeltaTime);

            if (hit.collider != null) 
                Debug.Log("ENCONTRO ENEMIGOssssssss");
            else
                Debug.Log("ENCONTRO NADA");
        }
    }
}
