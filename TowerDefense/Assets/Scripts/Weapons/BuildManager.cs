using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; // 使用static確保這是靜態類別

    void Awake() 
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene.");
            return;
        }
        instance = this; // 當前實體化的物件
    }


    public GameObject basicTurretPrefab; // 遊戲開始時預設的砲塔預置物

    void Start() 
    {
        turretToBuild = basicTurretPrefab;
    }

    private GameObject turretToBuild; // 要建造的砲塔

    public GameObject GetTurretTobuild()
    {
        return turretToBuild;
    }

}
