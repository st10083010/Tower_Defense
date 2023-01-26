using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 波次重生
/// </summary>
public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Transform basicEnemyPrefab;

    public Transform spawnPoint; // 生成點

    public float timeBetweenWaves = 5f; // 每波間隔秒數
    private float firstWave = 2.5f; // 第一波在幾秒後產生
    private int currentWave = 0; // 波次

    public WaveController[] waves;

    public TMP_Text waveCountdownText;
    public GameManager gameManager;
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }


        if (firstWave <= 0f)
        {
            StartCoroutine(SpawnWave());
            firstWave = timeBetweenWaves;
            return;
        }

        firstWave -= Time.deltaTime;

        firstWave = Mathf.Clamp(firstWave, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", firstWave);
        // 應該會加入時間倒數改變顏色
    }

    IEnumerator SpawnWave()
    {
        // 計算每波產生的敵人
        PlayerStats.Rounds++;
        WaveController wave = waves[currentWave];
        for (int i = 0; i < wave.enemies.Length; i++)
        {
            for (int j = 0; j < wave.enemies[i].count; j++)
            {
                SpawnEnemy(wave.enemies[i].enemy);
                yield return new WaitForSeconds(1 / wave.rate);
                // 每次迭代產生的物件以間隔0.5秒的方式產出
            }

        }

        currentWave++;

        if (currentWave == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

    
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        // 產生敵人
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

}
