using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver; // 檢查遊戲是否結束
    
    public GameObject gameOverUI;

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
}
