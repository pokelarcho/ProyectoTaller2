using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerTools;

public class HangarDoor : MonoBehaviour
{
    public GameObject collider;
    public AnimationClip animOpen;
    BoxCollider2D bx;
    SpriteAnim CompAnim;
    bool anim2 = false;
    public bool anim1 = false;
    public AudioClip sfxHangar;
    AudioSource ads;
    // Start is called before the first frame update
    void Start()
    {
        ads = GetComponent<AudioSource>();
        CompAnim = GetComponent<SpriteAnim>();
        bx = collider.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }



    public void AbrirPuerta() {
        if (anim1 == true)
        {
            if (anim2 == false)
            {
                
                ads.PlayOneShot(sfxHangar);
                StartCoroutine(Abrir());
            }
            anim2 = true;
        }

    }


    public void DestruirCollider() {
        bx.isTrigger = true;
    }

    IEnumerator Abrir()
    {

        yield return new WaitForSeconds(0.9f);
        CompAnim.Play(animOpen);


    }

}
