using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 節點UI
/// </summary>
public class NodeUI : MonoBehaviour
{
    private Node currentTarget; // 當前選擇的節點
    public GameObject uiSwitch; // UI狀態切換

    public void SetTarget(Node target)
    {
        currentTarget = target;
        transform.position = currentTarget.GetBuildPosition();
        uiSwitch.SetActive(true);
    }

    public void Hide()
    {
        uiSwitch.SetActive(false);
    }
}
