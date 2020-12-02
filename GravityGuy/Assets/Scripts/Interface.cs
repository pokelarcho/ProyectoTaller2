using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{

    public Sprite plusBoy;
    public Sprite plusGirl;
    public Sprite minusBoy;
    public Sprite minusGirl;

    public SpriteRenderer sr;

    private GameObject PlayerBoy;
    private PlayerMagnet pmag;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBoy = GameObject.Find("PlayerBoy");
        pmag = PlayerBoy.GetComponent<PlayerMagnet>();
        sr = GetComponent<SpriteRenderer>();
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
}
