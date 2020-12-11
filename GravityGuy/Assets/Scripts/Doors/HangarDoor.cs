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
    // Start is called before the first frame update
    void Start()
    {
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
                CompAnim.Play(animOpen);

                
            }
            anim2 = true;
        }

    }


    public void DestruirCollider() {
        bx.isTrigger = true;
    }



}
