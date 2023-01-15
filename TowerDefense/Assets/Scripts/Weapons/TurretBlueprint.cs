using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // 序列化資料,以便U在nity中使用(此處的類別並沒有從MonoBehaviour中繼承)
public class TurretBlueprint // : MonoBehaviour: 不從MonoBehaviour繼承而是獨立的class
{
    public GameObject prefab;
    public int cost;
}
