using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // 提示使用者游標移動到哪個節點上
    public Color hoverColor;
    private Renderer getRend;
    private Color startNodeColor;

    public Vector3 positionOffset; // 偏移量


    private GameObject currentTurret; // 當前節點上的砲塔數

    void Start() 
    {
        getRend = GetComponent<Renderer>();
        // 遊戲開始時只獲取一次Renderer並放入緩存中, 而不是每次當游標碰到Collider時都去獲取Renderer
        startNodeColor = getRend.material.color;
    }

    void OnMouseDown() 
    {
        if (currentTurret != null)
        {
            print("Can't built here");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretTobuild();
        currentTurret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
                        // 將物件轉換為GameObject
    }
    void OnMouseEnter() 
    {
        getRend.material.color = hoverColor;
    }

    void OnMouseExit() 
    {
        getRend.material.color = startNodeColor;
    }
}
