using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerTools;

public class SwitchPoleType : MonoBehaviour
{


    SpriteAnim CompAnim;
    public AnimationClip animdpositive;
    public AnimationClip animnegative;
    // Start is called before the first frame update
    void Start()
    {
        CompAnim = GetComponent<SpriteAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void switchToPositive() {
        CompAnim.Play(animdpositive);
    }

    public void switchToNegative()
    {
        CompAnim.Play(animnegative);
    }
}
