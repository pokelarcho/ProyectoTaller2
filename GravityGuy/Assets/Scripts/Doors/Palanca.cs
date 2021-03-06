﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    public Sprite SpriteChange;
    public bool Active;
    GameObject PlayerBoy;
    PlayerMovement pm;
    SpriteRenderer sr;
    public AudioClip sfxPush;
    AudioSource ads;
    void Start()
    {
        ads = GetComponent<AudioSource>();
        PlayerBoy = GameObject.Find("PlayerBoy");
        pm = PlayerBoy.GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pm.isDashing == true)
            {
                ads.PlayOneShot(sfxPush);
                Active = true;
                sr.sprite = SpriteChange;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pm.isDashing == true)
            {
                ads.PlayOneShot(sfxPush);
                Active = true;
                sr.sprite = SpriteChange;
            }
        }
    }
}
