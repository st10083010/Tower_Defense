using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    
    public Color hoverColor; // 提示使用者游標移動到哪個節點上
    public Color notEnoughMoneyColor; // 金額不足時的懸停顏色
    private Renderer getRend;
    private Color startNodeColor;

    public Vector3 positionOffset; // 偏移量

    BuildManager buildManager;

    [HideInInspector]
    public GameObject currentTurret; // 當前節點上的砲塔數
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    void Start() 
    {
        buildManager = BuildManager.instance;
        getRend = GetComponent<Renderer>();
        // 遊戲開始時只獲取一次Renderer並放入緩存中, 而不是每次當游標碰到Collider時都去獲取Renderer
        startNodeColor = getRend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        // 建立砲塔
        if (PlayerStats.Money < blueprint.cost)
        {
            // print("Not enought money to build that:(");
            return;
        }
        PlayerStats.Money -= blueprint.cost;


        GameObject turret = (GameObject)Instantiate(blueprint.prefabLv1, GetBuildPosition(), Quaternion.identity);
        // 將物件轉換為GameObject
        currentTurret = turret;
        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public int GetSellAmount()
    {
        // 取得販售價格 = 當前砲塔建立價格 + (升級價格) 除以 2
        int baseSellAmount = turretBlueprint.cost;

        if (isUpgraded)
        {
            baseSellAmount += turretBlueprint.upgradeCost;
        }

        return baseSellAmount / 2;
    }

    public void SellTurret()
    {
        // 販售砲塔
        PlayerStats.Money += GetSellAmount();
        Destroy(currentTurret);
        turretBlueprint = null;

        GameObject sellingEffect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(sellingEffect, 5f);
    }

    void OnMouseDown() 
    {
        if (EventSystem.current.IsPointerOverGameObject())
            // 避免節點(Nodes)被其他物件(這裡是UI的Button)擋住時依然能選擇節點並觸發後續事件
            return;



        if (currentTurret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    public void UpgradeTurret()
    {
        // 升級砲塔
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            // print("Not enought money to upgrade that:(");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(currentTurret);


        GameObject turret = (GameObject)Instantiate(turretBlueprint.prefabLv2, GetBuildPosition(), Quaternion.identity);
        // 將物件轉換為GameObject
        currentTurret = turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
    }

    void OnMouseEnter() 
    {
        if (EventSystem.current.IsPointerOverGameObject())
            // 避免節點(Nodes)被其他物件(這裡是UI的Button)擋住時依然能選擇節點並觸發後續事件
            return;

        if (!buildManager.CanBuild)
            return; // 當沒有選擇砲塔時不顯示懸停變色

        if (buildManager.HasMoney)
        {
            getRend.material.color = hoverColor;
        }else
        {
            getRend.material.color = notEnoughMoneyColor;
        }

        // if (currentTurret != null)
        // {
        //     getRend.material.color = notEnoughMoneyColor;
        // }
        
    }

    void OnMouseExit() 
    {
        getRend.material.color = startNodeColor;
    }
}
