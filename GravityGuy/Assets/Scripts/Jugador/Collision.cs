using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [Header("Layers")]
    public LayerMask groundLayer;

    public LayerMask vertigoLayer;
    private PlayerMovement pm;
    

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
    public Vector2 bottomOffset;
    private Color debugCollisionColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //GROUNDED EN VERTIGO
        onVertigo = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, vertigoLayer);

            pm.grounded = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset};
      
        Gizmos.DrawWireSphere((Vector2)transform.position  + bottomOffset, collisionRadius);
        
    }
}
