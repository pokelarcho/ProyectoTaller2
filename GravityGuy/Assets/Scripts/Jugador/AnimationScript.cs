using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    private Animator anim;
    private PlayerMovement move;
    private Death death;
    private PlayerMagnet playermag;
    public RuntimeAnimatorController cBoy;
    public RuntimeAnimatorController cGirl;

    [HideInInspector]
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        move = GetComponentInParent<PlayerMovement>();
        death = GetComponentInParent<Death>();
        playermag = GetComponentInParent<PlayerMagnet>();
        sr = GetComponent<SpriteRenderer>();

        if(PlayerSelect.genre == 1)
            anim.runtimeAnimatorController = cBoy;
        else
            anim.runtimeAnimatorController = cGirl;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("grounded", move.grounded);
        anim.SetBool("canMove", move.canMove);
        anim.SetBool("isDashing", move.isDashing);
        anim.SetBool("isDeath", death.isDeath);
        anim.SetBool("MagnetAction", playermag.magnetAction);
        anim.SetBool("magnetism", playermag.magnetism);
    }

    public void SetHorizontalMovement(float x, float y, float yVel, float xVel, bool vertigo)
    {

        if (!vertigo) {
            anim.SetFloat("HorizontalAxis", x);
            anim.SetFloat("VerticalAxis", y);
            anim.SetFloat("VerticalVelocity", yVel);
            anim.SetFloat("HorizontalVelocity", xVel);
        }
        else{
       
            anim.SetFloat("HorizontalAxis", x * -1);
            anim.SetFloat("VerticalAxis", y * -1);
            anim.SetFloat("VerticalVelocity", yVel * -1);
            anim.SetFloat("HorizontalVelocity", xVel * -1);
        }
    }

    public void SetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    public void Flip(int side)
    {
        bool state = (side == 1) ? false : true;
        sr.flipX = state;
    }
}
