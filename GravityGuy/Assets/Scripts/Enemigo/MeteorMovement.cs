using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 direccion;
    private float counter;
    // Start is called before the first frame update




    void Update()
    {
        rb.MovePosition(rb.position + direccion * moveSpeed * Time.fixedDeltaTime);

        counter += Time.deltaTime;

        //if (counter >= 5f)
            Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(this.gameObject);
    }

}
