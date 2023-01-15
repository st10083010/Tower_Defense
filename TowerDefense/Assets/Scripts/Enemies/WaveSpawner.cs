using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform basicEnemyPrefab;

    public Transform spawnPoint; // 生成點

    public float timeBetweenWaves = 5f; // 每波間隔秒數
    private float firstWave = 2.5f; // 第一波在幾秒後產生
    private int currentWave = 0; // 波次

    public TMP_Text waveCountdownText;

    void Update()
    {
        if (firstWave <= 0f)
        {
            StartCoroutine(SpawnWave());
            firstWave = timeBetweenWaves;
        }

        firstWave -= Time.deltaTime;

        firstWave = Mathf.Clamp(firstWave, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", firstWave);
        // 應該會加入時間倒數改變顏色
    }

    IEnumerator SpawnWave()
    {
        currentWave++;
        for (int i = 0; i < currentWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
            // 每次迭代展生的物件以間隔0.5秒的方式產出
        }
    }

    void SpawnEnemy()
    {
        Instantiate(basicEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
