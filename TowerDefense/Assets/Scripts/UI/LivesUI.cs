using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TMP_Text livesText; // 生命值

    // Update is called once per frame
    void Update()
    {
        livesText.text = $"{PlayerStats.Lives}";
    }
}
