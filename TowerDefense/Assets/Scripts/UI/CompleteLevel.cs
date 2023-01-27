using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    public string mainMenuName = "MainMenu"; // 載入場景的字串



    public void Coutinue()
    {
        // 繼續
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

    public void Menu()
    {
        // 選單
        sceneFader.FadeTo(mainMenuName);
    }
}
