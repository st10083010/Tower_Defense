using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

/// <summary>
/// 遊戲結束
/// </summary>
public class GameOver : MonoBehaviour
{
    public TMP_Text roundsText; // 回合數

    public SceneFader sceneFader;
    public string mainMenuName = "MainMenu"; // 載入場景的字串

    void OnEnable() 
    {
        // 每次被啟用時調用
        roundsText.text = $"{PlayerStats.Rounds}";
    }

    public void Replay()
    {
        // 重玩
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        // 選單
        sceneFader.FadeTo(mainMenuName);
    }
}
