using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target; // 宣告一個變數, 被追蹤目標的位置訊息

    public float bulletSpeed = 70f; // 子彈速度
    public GameObject impactEffect; // 衝擊特效粒子
    public void Chase(Transform _target)
    {
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
    }

    void HitTarget()
    {
        GameObject effectInstantiate = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation); // 實體化物件
        Destroy(effectInstantiate, 2f); // 兩秒後摧毀實體化的粒子
        Destroy(target.gameObject); // 摧毀目標
        Destroy(gameObject);
    }
}
