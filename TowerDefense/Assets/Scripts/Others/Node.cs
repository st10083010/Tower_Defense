using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    // 提示使用者游標移動到哪個節點上
    public Color hoverColor;
    private Renderer getRend;
    private Color startNodeColor;

    public Vector3 positionOffset; // 偏移量

    BuildManager buildManager;


    private GameObject currentTurret; // 當前節點上的砲塔數

    void Start() 
    {
        buildManager = BuildManager.instance;
        getRend = GetComponent<Renderer>();
        // 遊戲開始時只獲取一次Renderer並放入緩存中, 而不是每次當游標碰到Collider時都去獲取Renderer
        startNodeColor = getRend.material.color;
    }

    void OnMouseDown() 
    {
        if (EventSystem.current.IsPointerOverGameObject())
            // 避免節點(Nodes)被其他物件(這裡是UI的Button)擋住時依然能選擇節點並觸發後續事件
            return;

        if (buildManager.GetTurretTobuild() == null)
            return;

        if (currentTurret != null)
        {
            print("Can't built here");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretTobuild();
        currentTurret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
                        // 將物件轉換為GameObject
    }
    void OnMouseEnter() 
    {
        if (EventSystem.current.IsPointerOverGameObject())
            // 避免節點(Nodes)被其他物件(這裡是UI的Button)擋住時依然能選擇節點並觸發後續事件
            return;

        if (buildManager.GetTurretTobuild() == null)
            return; // 當沒有選擇砲塔時不顯示懸停變色

        getRend.material.color = hoverColor;
    }

    void OnMouseExit() 
    {
        getRend.material.color = startNodeColor;
    }
}
