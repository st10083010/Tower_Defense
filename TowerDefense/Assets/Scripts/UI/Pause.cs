using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseUI;

    public SceneFader sceneFader;
    public string mainMenuName = "MainMenu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BouncePause();
        }
    }

    public void BouncePause()
    {
        // 暫停畫面與停止時間
        pauseUI.SetActive(!pauseUI.activeSelf);

        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
    }

    public void Replay()
    {
        // 重新開始
        BouncePause();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        print(SceneManager.GetActiveScene().name);
        
    }

    public void Menu()
    {
        // 選單
        BouncePause();
        sceneFader.FadeTo(mainMenuName);
    }
    
}
