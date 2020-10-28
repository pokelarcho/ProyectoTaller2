using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    private Animator anim;
    private PlayerMovement move;
    
    [HideInInspector]
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        
        move = GetComponentInParent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("grounded", move.grounded);
        anim.SetBool("canMove", move.canMove);
        anim.SetBool("isDashing", move.isDashing);
    }

    public void SetHorizontalMovement(float x, float y, float yVel, bool vertigo)
    {

        if (!vertigo) { 
        anim.SetFloat("HorizontalAxis", x);
        anim.SetFloat("VerticalAxis", y);
        anim.SetFloat("VerticalVelocity", yVel);
        }else{
        anim.SetFloat("HorizontalAxis", x);
        anim.SetFloat("VerticalAxis", y);
        anim.SetFloat("VerticalVelocity", yVel);
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
