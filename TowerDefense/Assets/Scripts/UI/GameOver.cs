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

    void OnEnable() 
    {
        // 每次被啟用時調用
        roundsText.text = $"{PlayerStats.Rounds}";
    }

    public void Replay()
    {
        // 重玩
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        // 選單
        print("go to menu");
    }
}
