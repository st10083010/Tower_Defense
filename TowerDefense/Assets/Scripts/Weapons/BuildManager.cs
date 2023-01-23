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


    public GameObject buildEffect; // 建立時特效
    public GameObject sellEffect; // 販售時特效


    private TurretBlueprint turretToBuild; // 要建造的砲塔
    private Node selectedNode; // 選擇的節點

    public bool CanBuild { get { return turretToBuild != null; } } // CSharp Property
    // 建立一個CanBuild的變數, 當嘗試get資料時, 檢查turretToBuild, 不等於null就回傳true, 否則回傳false

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public NodeUI nodeUI; // 顯示的Node UI

    public void SelectNode (Node node)
    {
        // 選擇節點
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        // 選擇要建立的砲塔
        turretToBuild = turret;
        DeselectNode();
    }

    public void DeselectNode()
    {
        // 取消選擇節點
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
