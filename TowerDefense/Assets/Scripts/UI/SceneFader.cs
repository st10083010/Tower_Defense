using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img; // 轉場圖片

    void Start() 
    {
        // StartCoroutine(FadeIn());
    }

    IEnumerable FadeIn()
    {
        float t = 1f;
        print(t);
        while (t > 0f)
        {
            t -= Time.deltaTime;
            img.color = new Color (0f, 0f, 0f, t);
            print(t);
            yield return 0;
        }
    }
}
