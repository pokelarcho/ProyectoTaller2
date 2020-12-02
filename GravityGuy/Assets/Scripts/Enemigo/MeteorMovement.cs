﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerTools;

public class MeteorMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 direccion;
    SpriteAnim CompAnim;
    public AnimationClip animdestruct;
    private float counter;
    // Start is called before the first frame update

    private void Start()
    {
        CompAnim = GetComponent<SpriteAnim>();
    }


    void Update()
    {
        rb.MovePosition(rb.position + direccion * moveSpeed * Time.fixedDeltaTime);

        counter += Time.deltaTime;

        if (counter >= 3f)
            Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            moveSpeed = 0;
            CompAnim.Play(animdestruct);
            
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = 0;
            CompAnim.Play(animdestruct);
            
        }
    }


    public void Destroy()
    {

        Destroy(this.gameObject);
    }
}
