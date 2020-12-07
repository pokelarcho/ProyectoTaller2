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

    void Start()
    {
        p = palanca.GetComponent<Palanca>();
        bx = GetComponent<BoxCollider2D>();
        CompAnim = GetComponent<SpriteAnim>();
    }
    void Update()
    {
        if (p.Active == true)
        {
            if (anim2 == false)
            {
                CompAnim.Play(animdestruct);

                bx.isTrigger = true;
            }
            anim2 = true;
        }
    }

    public void destruirPuerta()
    {
        Destroy(this.gameObject);
    }
}
