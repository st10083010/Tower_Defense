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


    public GameObject basicTurretPrefab;
    public GameObject missileLauncherPrefab;


    private TurretBlueprint turretToBuild; // 要建造的砲塔

    public bool CanBuild { get { return turretToBuild != null; } } // CSharp Property
    // 建立一個CanBuild的變數, 當嘗試get資料時, 檢查turretToBuild, 不等於null就回傳true, 否則回傳false

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }


    public void BuildTurretON(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            print("Not enought money to build that:(");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;


        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        // 將物件轉換為GameObject
        node.currentTurret = turret;

        print($"Turret build! Money left: {PlayerStats.Money}");
    }
}
