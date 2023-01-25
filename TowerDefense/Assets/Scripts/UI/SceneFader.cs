using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img; // 轉場圖片
    public AnimationCurve curve; // 變更淡入淡出的曲線變化, 而不是平滑的從0變成1

    void Start() 
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo (string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        // 淡入
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            float alphaValue = curve.Evaluate(t);
            img.color = new Color (0f, 0f, 0f, alphaValue);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        // 淡出
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            float alphaValue = curve.Evaluate(t);
            img.color = new Color (0f, 0f, 0f, alphaValue);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
