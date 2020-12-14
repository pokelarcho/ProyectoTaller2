using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FInalDestination : MonoBehaviour
{
    public GameObject palanca01;
    public GameObject palanca02;
    public GameObject palanca03;
    public GameObject palanca04;
    Palanca p01;
    Palanca p02;
    Palanca p03;
    Palanca p04;
    public Animator transition;

    void Start()
    {
        p01 = palanca01.GetComponent<Palanca>();
        p02 = palanca02.GetComponent<Palanca>();
        p03 = palanca03.GetComponent<Palanca>();
        p04 = palanca04.GetComponent<Palanca>();
        
        
    }
    void Update()
    {
        if (p01.Active == true && p02.Active == true && p03.Active == true && p04.Active == true)
        {
            StartCoroutine(LoadLevel());

        }
    }

    
    IEnumerator LoadLevel()
    {

        transition.SetTrigger("start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("YouWin");
    }
}