using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerTools;

public class PushDoor : MonoBehaviour
{
    public GameObject palanca;
    Palanca p;
    BoxCollider2D bx;
    SpriteAnim CompAnim;
    public AnimationClip animdestruct;
    bool anim2=false;
    public AudioClip sfxDestruct;
    AudioSource ads;
    void Start()
    {
        p = palanca.GetComponent<Palanca>();
        bx = GetComponent<BoxCollider2D>();
        CompAnim = GetComponent<SpriteAnim>();
        ads = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (p.Active == true)
        {
            if (anim2 == false)
            {
                StartCoroutine(Destruir());

                bx.isTrigger = true;
            }
            anim2 = true;
        }
    }

    public void destruirPuerta()
    {
        Destroy(this.gameObject);
    }


    IEnumerator Destruir()
    {
        
        yield return new WaitForSeconds(1f);
        ads.PlayOneShot(sfxDestruct);
        CompAnim.Play(animdestruct);


    }
}
