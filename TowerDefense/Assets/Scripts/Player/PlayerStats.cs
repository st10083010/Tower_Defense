using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家數據
/// </summary>
public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    void Start() 
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }
}
