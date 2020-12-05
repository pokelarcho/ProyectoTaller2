using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interface : MonoBehaviour
{
    public static Interface instance;
    public Sprite plusBoy;
    public Sprite plusGirl;
    public Sprite minusBoy;
    public Sprite minusGirl;
    
    public SpriteRenderer sr;
    public ParticleSystem poleEffect;
    private GameObject PlayerBoy;
    private PlayerMagnet pmag;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBoy = GameObject.Find("PlayerBoy");
        pmag = PlayerBoy.GetComponent<PlayerMagnet>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSelect.genre == 1) {
            if (pmag.polo)
                sr.sprite= plusBoy;
            else
                sr.sprite = minusBoy;

        }
        else if(PlayerSelect.genre == 2)
        {
            if (pmag.polo)
                sr.sprite = plusGirl;
            else
                sr.sprite = minusGirl;
        }
    }


    public void PoleEffector(bool Cooldown) {

        var emission = poleEffect.emission;
        emission.enabled = !Cooldown;

    }
}
