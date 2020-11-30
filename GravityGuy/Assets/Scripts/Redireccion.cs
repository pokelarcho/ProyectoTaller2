using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Redireccion : MonoBehaviour
{
    public void Change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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

 

}
