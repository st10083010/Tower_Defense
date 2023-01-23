using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// 節點UI
/// </summary>
public class NodeUI : MonoBehaviour
{
    private Node currentTarget; // 當前選擇的節點
    public GameObject uiSwitch; // UI狀態切換(開關)

    public TMP_Text upgradeCost; // 升級價格
    public Button upgradeButton; // 升級按鈕

    public TMP_Text sellAmount; // 販售價格

    public void SetTarget(Node target)
    {
        // 設置砲塔
        currentTarget = target;
        transform.position = currentTarget.GetBuildPosition();
        uiSwitch.SetActive(true);

        if (currentTarget.isUpgraded == false){
            upgradeButton.interactable = true;
            upgradeCost.text = $"$ {currentTarget.turretBlueprint.upgradeCost}";
        }else{
            upgradeButton.interactable = false;
            upgradeCost.text = "Complete";
        }

        sellAmount.text = $"$ {currentTarget.GetSellAmount()}";
        
    }

    public void Hide()
    {
        // 隱藏
        uiSwitch.SetActive(false);
    }

    public void Upgrade()
    {
        // 升級
        currentTarget.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        // 販售
        currentTarget.SellTurret();
        currentTarget.isUpgraded = false;
        BuildManager.instance.DeselectNode(); // 賣出後取消選擇節點
    }
}
