using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵人行為控制
/// </summary>
[RequireComponent(typeof(Enemy))]
public class EneimiesMovement : MonoBehaviour
{   

    private Transform target;
    private int wavepointIndex = 0;
    private Enemy enemy;

    void Start() {
        enemy = GetComponent<Enemy>();
        target = Waypoint.points[0];
    }


    void Update() {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            // 如果transform.position跟target.position的距離小於0.2
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
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
