using UnityEngine;
using DG.Tweening;


public class GhostTrail : MonoBehaviour
{
    private PlayerMovement move;

    private AnimationScript anim;
    private SpriteRenderer sr;
    public Transform ghostsParent;
    public Color trailColor;
    public Color fadeColor;
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
        Debug.Log(cs.vertigo);

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
            s.Append(currentGhost.GetComponent<SpriteRenderer>().material.DOColor(trailColor, 0));
            s.AppendCallback(() => FadeSprite(currentGhost));
            s.AppendInterval(ghostInterval);
        }
    }

    public void FadeSprite(Transform current)
    {
        current.GetComponent<SpriteRenderer>().material.DOKill();
        current.GetComponent<SpriteRenderer>().material.DOColor(fadeColor, fadeTime);
    }

}
