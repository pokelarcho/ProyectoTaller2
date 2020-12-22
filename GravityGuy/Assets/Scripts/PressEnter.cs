using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PressEnter : MonoBehaviour
{
    public Button Boton;
    public Animator transition;
    float timer=0;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public AudioClip sfxPush;
    AudioSource ads; 
    // Start is called before the first frame update
    void Start()
    {
        Boton.enabled = false;
        ads = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Boton.enabled == false)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ads.PlayOneShot(sfxPush);
                transition.SetTrigger("start");
                Boton.enabled = true;
                Boton.Select();
                Boton.OnSelect(null);
                gameObject1.SetActive(false);
                gameObject2.SetActive(false);

                timer = 0;

            }

            if (timer >= 1)
            {
                gameObject1.SetActive(false);
                gameObject2.SetActive(false);

            }

            if (timer >= 2)
            {
                gameObject1.SetActive(true);
                gameObject2.SetActive(true);
                timer = 0;
            }



        }

    }
}
