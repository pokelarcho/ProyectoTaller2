using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerTools;

public class WeaponDestroy : MonoBehaviour
{
    bool destroy;
    float timer;
    float maxTimer;
    public AnimationClip animdestruct;
    SpriteAnim CompAnim;
    bool anim2=false;
    void Start()
    {
        
        
        CompAnim = GetComponent<SpriteAnim>();
        maxTimer = 1.5f;
    }
    void Update()
    {
        if (destroy)
        {
            leave();
        }
    }
    void leave()
    {
        if (anim2 == false)
        {
            timer += Time.deltaTime;
            if (timer >= maxTimer)
            {
                CompAnim.Play(animdestruct);
                anim2 = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            destroy = true;
        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
