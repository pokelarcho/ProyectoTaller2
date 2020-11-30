using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destructorss : MonoBehaviour
{

    public GameObject menuprin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destructor"))
        {
            Destroy(gameObject);

            SceneManager.LoadScene("PantallaPrincipal");

        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("PantallaPrincipal");
        }
    }
}
