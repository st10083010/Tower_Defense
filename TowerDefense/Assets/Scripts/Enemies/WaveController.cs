using UnityEngine;

/// <summary>
/// 波次控制器
/// </summary>
[System.Serializable]
public class WaveController
{
    public WaveDetail[] enemies; // 敵人預置物(可放不同種敵人)
    public float rate;

    [System.Serializable]
    public class WaveDetail{
        public GameObject enemy;
        public int count; // 每波產生的總敵人
    }
    
    
}
