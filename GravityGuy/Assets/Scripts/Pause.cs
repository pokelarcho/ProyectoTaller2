using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject LivesUI;
    public GameObject x;
    public GameObject Lives;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused){
                Resume();
            }
            else{
                Pausa();
            }
        }
    }

    void Resume(){
       pauseMenuUI.SetActive(false);
       //LivesUI.SetActive(true);
        Time.timeScale = 1f;
      GameIsPaused = false;
    }

    void Pausa(){
      pauseMenuUI.SetActive(true);
       //LivesUI.SetActive(false);
        Time.timeScale = 0f;
      GameIsPaused = true;
    }
}
