using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 攻擊設計: 1. 鎖定範圍內最近的目標並攻擊; 2. 旋轉砲塔並指向目標
public class Turret : MonoBehaviour
{
    private Transform target;
    public float attackRange = 15f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float rotationSpeed = 10f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        // 在時間秒內調用方法 methodName，然後每隔 repeatRate 秒重複一次。
    }

    void UpdateTarget()
    {
        // 追蹤目標, 每秒檢查兩次, 避免過度消耗資源
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; // 最短距離(這裡設為無限大)
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // 與敵人的距離

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= attackRange)
        {
            target = nearestEnemy.transform;
        }else{
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        // 鎖定目標
        Vector3 pointEnemy = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(pointEnemy);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
    }

    void OnDrawGizmosSelected() 
    {
        // 當物件被選中時繪製Gizmo
        Gizmos.color = Color.red; // 繪製的顏色
        Gizmos.DrawWireSphere(transform.position, attackRange); // 繪製具有中心和半徑的線框球體。
    }
}
