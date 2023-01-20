using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 攻擊設計: 1. 鎖定範圍內最近的目標並攻擊; 2. 旋轉砲塔並指向目標
public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("General")] // 自定義Header, 用於整理Unity編輯器中顯示的public數據
    public float attackRange = 15f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab; // 子彈預置物
    public float fireRate = 1f; // 射速
    private float fireCountdown = 0f; // 開火倒數

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer; // 雷射光束
    public ParticleSystem impactEffect; // 雷射衝擊特效
    public Light impactLight; // 雷射光源

    [Header("Unity setup fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float rotationSpeed = 10f;
    public Transform firePoint; // 子彈射出點
    public float turnSpeed = 10f;


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
            if (useLaser && lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }else{
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }

    }

    void Laser()
    {
        // 使用雷射時觸發

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        
    }

    void OnDrawGizmosSelected() 
    {
        // 當物件被選中時繪製Gizmo
        Gizmos.color = Color.red; // 繪製的顏色
        Gizmos.DrawWireSphere(transform.position, attackRange); // 繪製具有中心和半徑的線框球體。
    }

    void Shoot()
    {
        // 射擊時
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // 實體化子彈預置物
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Chase(target);
        }
    }

    void LockOnTarget()
    {
        // 鎖定目標時
        Vector3 pointEnemy = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(pointEnemy);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
