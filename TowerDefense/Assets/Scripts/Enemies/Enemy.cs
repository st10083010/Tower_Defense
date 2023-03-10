using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 敵人數值
/// </summary>
public class Enemy : MonoBehaviour
{
    [Header("Enemy Attribute")]
    public float startSpeed = 10f; // 起始速度
    public float startHealth = 100f; // 初始生命值
    private float currentHealth; // 當前生命值
    public int gold = 50;
    public GameObject deathEffect; // 死亡效果

    [Header("Unity Stuff")]
    public Image healthBar; // 生命值

    [HideInInspector]
    public float speed;

    private bool enemyDiesOnlyOne;

    void Start()
    {
        speed = startSpeed;
        enemyDiesOnlyOne = false;
        currentHealth = startHealth;
    }

    void Update()
    {
        if (enemyDiesOnlyOne)
        {
             // 設定敵人只能死一次, 避免多個砲塔同時(frame)擊殺同一個敵人時造成金錢累加
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        // 敵人受到傷害時
        currentHealth -= damage;

        healthBar.fillAmount = currentHealth / startHealth;

        if (currentHealth <= 0f)
        {
            enemyDiesOnlyOne = true;
        }
    }

    void Die()
    {
        // 敵人死亡時
        PlayerStats.Money += gold;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

        WaveSpawner.EnemiesAlive--;
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    public void Slow(float percent)
    {
        speed = startSpeed * (1f - percent);
    }
}
