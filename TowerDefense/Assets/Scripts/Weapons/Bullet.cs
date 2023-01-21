using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子彈資訊
/// </summary>
public class Bullet : MonoBehaviour
{
    private Transform target; // 宣告一個變數, 被追蹤目標的位置訊息

    public float bulletSpeed = 70f; // 子彈速度
    public GameObject impactEffect; // 衝擊特效粒子
    public float explosionRadius = 0f; // 爆炸半徑
    public int damege = 50; // 子彈傷害
    public void Chase(Transform _target)
    {
        // 子彈跟隨
        target = _target;
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // 避免子彈找不到目標
            return;
        }

        Vector3 bulletDirection = target.position - transform.position; // 結束時的位置減掉當前位置
        float distanceThisFrame = bulletSpeed * Time.deltaTime; // 這一張影格實際移動的距離

        if (bulletDirection.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(bulletDirection.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target); // 物件的Z軸隨著目標旋轉
    }

    void HitTarget()
    {
        // 擊中目標
        GameObject effectInstantiate = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation); // 實體化物件
        Destroy(effectInstantiate, 2f); // 兩秒後摧毀實體化的粒子

        if (explosionRadius > 0f)
        {
            Explode();
        }else
        {
            Damage(target);
        }

        
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        // 造成傷害
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damege);
        }
        
    }

    void Explode()
    {
        // 爆炸
       Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); // 回傳碰撞到或在球體內的array
       foreach(Collider collider in colliders)
       {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
       }
    }

    void OnDrawGizmosSelected()
    {
        // 顯示子彈傷害範圍
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
