using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Redireccion : MonoBehaviour
{

    public Animator transition;
    public void Change(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
        
    }

    public void Quit() {
        Application.Quit();
    }

    public void SwitchCharacter(int numberplayer)
    {
        PlayerSelect.genre = numberplayer;
    }

    public void EnableTime() {
        Time.timeScale = 1f;
    }


    IEnumerator LoadLevel(string sceneName) {

        transition.SetTrigger("start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }
}
