using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel"; // 載入場景的字串

    public SceneFader sceneFader;

    public void StartGame()
    {
        // 開始遊戲
        sceneFader.FadeTo(levelToLoad);

    }

    public void ExitGame()
    {
        // 離開遊戲
        print("888");
        Application.Quit();
    }
}
