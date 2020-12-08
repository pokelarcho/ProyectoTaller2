using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Redir : MonoBehaviour
{

    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel("PantallaPrincipal"));
            
        }
    }

    IEnumerator LoadLevel(string sceneName)
    {

        transition.SetTrigger("start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }

}
