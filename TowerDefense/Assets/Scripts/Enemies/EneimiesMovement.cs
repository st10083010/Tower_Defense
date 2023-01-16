using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneimiesMovement : MonoBehaviour
{   
    [Header("Enemy Attribute")]
    public float speed = 10f;
    public int health = 100;
    public int gold = 50;
    public GameObject deathEffect; // 死亡效果
    private Transform target;
    private int wavepointIndex = 0;

    void Start() {
        target = Waypoint.points[0];
    }

    public void TakeDamage(int damage)
    {
        // 敵人受到傷害時
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // 敵人死亡時
        PlayerStats.Money += gold;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    void Update() {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            // 如果transform.position跟target.position的距離小於0.2
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        // 前往下一個導航點
        if (wavepointIndex >= (Waypoint.points.Length - 1))
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }

    void EndPath()
    {
        // 走到終點時
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
