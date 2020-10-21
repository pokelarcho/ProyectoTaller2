using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poff : MonoBehaviour
{

    public float speed = -20f;
    public Rigidbody2D rb;
    private float counter;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= 3.5f)
            Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
