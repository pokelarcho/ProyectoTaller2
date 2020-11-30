using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerTools;

public class RedDoor : MonoBehaviour
{

    private GameObject PlayerBoy;
    private PlayerMovement pm;
    SpriteAnim CompAnim;
    public AnimationClip animdestruct;
    BoxCollider2D bx;
    // Start is called before the first frame update
    void Start()
    {
        PlayerBoy = GameObject.Find("PlayerBoy");
        pm = PlayerBoy.GetComponent<PlayerMovement>();
        CompAnim = GetComponent<SpriteAnim>();
        bx = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (pm.isDashing = true)
            {
                CompAnim.Play(animdestruct);
                bx.isTrigger = true;
            }
            
        }

    }

    public void destruirPuerta() {

        Destroy(this.gameObject);
    }
}
