using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{

    public AudioClip bgmMusic;
    AudioSource ads;
    // Start is called before the first frame update
    void Start()
    {
        ads = GetComponent<AudioSource>();

        ads.PlayOneShot(bgmMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
