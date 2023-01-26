using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 關卡選擇器
/// </summary>
public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFader;
    public Button[] levelButtons; // 關卡按鈕

    void Start() {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false; // 禁用按鈕
            }
            
        }
    }

    public void Select (string levelName)
    {
        // 選擇關卡
        sceneFader.FadeTo(levelName);
    }
}
