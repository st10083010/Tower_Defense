using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver; // 檢查遊戲是否結束
    
    public GameObject gameOverUI;
    public SceneFader sceneFader;

    void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
            return;

        // if (Input.GetKey("e"))
        // {
        //     // test gameover
        //     GameOver();
        // }

        if (PlayerStats.Lives <= 0)
        {
            PlayerStats.Lives = 0;
            GameOver();
        }
    }

    void GameOver()
    {
        GameIsOver = true;
        // print("game over:(");
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        print("LEVEL WON!");
        int checkLevel = PlayerPrefs.GetInt("levelReached");
        PlayerPrefs.SetInt("levelReached", checkLevel + 1);

        string getScene = SceneManager.GetActiveScene().name.Split("_")[1];
        
        if (int.Parse(getScene) < PlayerPrefs.GetInt("levelReached"))
        {
            SceneManager.LoadScene("LevelSelector");
        }

        if (PlayerPrefs.GetInt("levelReached") <= 9)
        {
            sceneFader.FadeTo($"Level_0{PlayerPrefs.GetInt("levelReached")}");
        }else{
            sceneFader.FadeTo($"Level_{PlayerPrefs.GetInt("levelReached")}");
        }
        
    }
}
