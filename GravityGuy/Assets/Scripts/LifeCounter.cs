using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCounter : MonoBehaviour
{

     public TextMeshProUGUI Vidas;

    private GameObject PlayerBoy;
    private Death death;

    // Start is called before the first frame update
    void Start()
    {
        
        PlayerBoy = GameObject.Find("PlayerBoy");
        death = PlayerBoy.GetComponent<Death>();
    }

    // Update is called once per frame
    void Update()
    {
        Vidas.text = death.lives.ToString("0");
        /*if (!Vidas.text.Equals(death.lives.ToString()))
            StartCoroutine(Pulse());*/

            
        
    }

    private IEnumerator Pulse() {

        for (float i = 1f; i <= 1.2f; i += 0.05f)
        {
            Vidas.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        Vidas.rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

        Vidas.text = death.lives.ToString("0");

        for (float i = 1.2f; i <= 1f; i += 0.05f)
        {
            Vidas.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        Vidas.rectTransform.localScale = new Vector3(0.5f, 0.5f,0.5f);
    }
}
