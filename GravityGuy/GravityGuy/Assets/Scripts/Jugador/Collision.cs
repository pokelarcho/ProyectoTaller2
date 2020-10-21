using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [Header("Layers")]
    public LayerMask groundLayer;

    public LayerMask vertigoLayer;

    

    [Space]

    public bool onGround;
    /*public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;*/
    public bool onVertigo=true;
    public int wallSide;

    [Space]

    [Header("Collision")]

    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, upOffset;
    private Color debugCollisionColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GROUNDED EN VERTIGO
        onVertigo = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, vertigoLayer);
        
        
            onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
/*
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer)
            || Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);
        
        */
        
        
        //wallSide = onRightWall ? -1 : 1;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, upOffset };
      
        Gizmos.DrawWireSphere((Vector2)transform.position  + bottomOffset, collisionRadius);
       /* Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);*/
        Gizmos.DrawWireSphere((Vector2)transform.position + upOffset, collisionRadius);
    }
}
