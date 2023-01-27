using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 回合生存數
/// </summary>
public class RoundSurvived : MonoBehaviour
{
    public TMP_Text roundsText; // 回合數

    void OnEnable() 
    {
        // 每次被啟用時調用
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText ()
    {
        // 計算總生存回合的動畫控制
        int firstRounds = 0;
        roundsText.text = $"{firstRounds}";

        yield return new WaitForSeconds(0.7f); // 避免淡入淡出效果遮住了實際計算回合數時的動畫

        while (firstRounds < PlayerStats.Rounds)
        {
            firstRounds++;
            roundsText.text = $"{firstRounds}";

            yield return new WaitForSeconds(0.05f);
        }
    }
}
