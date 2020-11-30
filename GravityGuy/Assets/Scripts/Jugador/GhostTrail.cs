﻿using UnityEngine;
using DG.Tweening;


public class GhostTrail : MonoBehaviour
{
    private PlayerMovement move;

    private AnimationScript anim;
    private SpriteRenderer sr;
    public Transform ghostsParent;
    public Color trailColor;
    public Color fadeColor;
    public Color trailColor2;
    public Color fadeColor2;
    public float ghostInterval;
    public float fadeTime;
    private GameObject PlayerBoy;
    private PlayerMovement cs;
    private SpriteRenderer psr;
  


    private void Start()
    {
        anim = FindObjectOfType<AnimationScript>();
        move = FindObjectOfType<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        //Llamar a un objeto muy parte de este
        PlayerBoy = GameObject.Find("PlayerBoy");
        cs = PlayerBoy.GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        

        if(cs.vertigo == true)
            ghostsParent.SetScaleY(-1);
        else
            ghostsParent.SetScaleY(1);
    }






    public void ShowGhost()
    {
        Sequence s = DOTween.Sequence();

        for (int i = 0; i < ghostsParent.childCount; i++)
        {
            Transform currentGhost = ghostsParent.GetChild(i);
            s.AppendCallback(() => currentGhost.position = move.transform.position);
            s.AppendCallback(() => currentGhost.GetComponent<SpriteRenderer>().flipX = anim.sr.flipX);
            s.AppendCallback(() => currentGhost.GetComponent<SpriteRenderer>().sprite = anim.sr.sprite);
            if(PlayerSelect.genre==1)
               s.Append(currentGhost.GetComponent<SpriteRenderer>().material.DOColor(trailColor, 0));
            else
                s.Append(currentGhost.GetComponent<SpriteRenderer>().material.DOColor(trailColor2, 0));
            s.AppendCallback(() => FadeSprite(currentGhost));
            s.AppendInterval(ghostInterval);
        }
    }

    public void FadeSprite(Transform current)
    {
        current.GetComponent<SpriteRenderer>().material.DOKill();
        if (PlayerSelect.genre == 1)
            current.GetComponent<SpriteRenderer>().material.DOColor(fadeColor, fadeTime);
        else
            current.GetComponent<SpriteRenderer>().material.DOColor(fadeColor2, fadeTime);
    }

}
