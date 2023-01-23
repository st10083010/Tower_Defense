using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // 序列化資料,以便在Unity中使用(此處的類別並沒有從MonoBehaviour中繼承)

/// <summary>
/// 砲塔藍圖
/// </summary>
public class TurretBlueprint // : MonoBehaviour: 不從MonoBehaviour繼承而是獨立的class
{
    public GameObject prefabLv1; // 1等砲塔
    public int cost;

    public GameObject prefabLv2; // 2等砲塔
    public int upgradeCost;
}
