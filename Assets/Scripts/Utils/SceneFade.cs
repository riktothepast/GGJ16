using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    public CanvasGroup canvas;
    public float fadeSpeed = 1.5f;
    public bool sceneStarting = true;
    float alpha = 1f;
    int sceneNumber;

    void OnEnable()
    {
        canvas.alpha = 0;
        if (sceneStarting)
            StartScene();
    }

    void FadeToClear()
    {
        alpha = Mathf.MoveTowards(alpha, 0, fadeSpeed * Time.deltaTime);
        canvas.alpha = alpha;
    }


    void FadeToBlack()
    {
        alpha = Mathf.MoveTowards(alpha, 1, fadeSpeed * Time.deltaTime);
        canvas.alpha = alpha;
    }

    public void StartScene()
    {
        StartCoroutine(FadeToClearStart());
    }

    IEnumerator FadeToClearStart()
    {
        alpha = 1;
        while (canvas.alpha  > 0.02f)
        {
            FadeToClear();
            yield return null;   
        }
        canvas.alpha = 0;
        sceneStarting = false;
    }


    public void EndScene(int SceneNumber)
    {
        sceneNumber = SceneNumber;
        StartCoroutine(FadeToBlackEnd());
    }

    IEnumerator FadeToBlackEnd()
    {
        alpha = 0;
        while (canvas.alpha < 0.95f)
        {
            FadeToBlack();
            yield return null;
        }
        canvas.alpha = 1;
        Application.LoadLevel(sceneNumber);
    }
}