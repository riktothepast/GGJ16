﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IntroChanger : MonoBehaviour {
    public List<string> dialogues;
    public List<Sprite> sprites;

    public Image img, shadow;
    public Text text;
    int currentIndex = -1;
    public float timeToChage = 1f;
	// Use this for initialization
	void Start () {
        img.color = Color.clear;
        text.color= Color.white;
        Invoke("MoveToNextData", 1f);
        StartCoroutine(ShowShadowData());
	}

    void MoveToNextData()
    {
        StartCoroutine(FadeCurrentData());
    }
    IEnumerator ShowShadowData()
    {
        while (shadow.color.a < 0.95f)
        {
            shadow.color = Color.Lerp(shadow.color, Color.white, Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    IEnumerator FadeCurrentData()
    {
        while (text.color.a > 0.1f)
        {
            text.color = Color.Lerp(text.color, Color.clear, Time.deltaTime);
            img.color = Color.Lerp(img.color, Color.clear, Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        StartCoroutine(ShowCurrentData());
    }

    IEnumerator ShowCurrentData()
    {
        currentIndex++;
        if (currentIndex < dialogues.Count)
        {
            img.sprite = sprites[currentIndex];
            text.text = dialogues[currentIndex];

            while (text.color.a < 0.95f)
            {
                text.color = Color.Lerp(text.color, Color.white, Time.deltaTime);
                img.color = Color.Lerp(img.color, Color.white, Time.deltaTime);
                yield return new WaitForSeconds(Time.deltaTime);

            }
        }
        if (currentIndex < dialogues.Count)
            MoveToNextData();
        else
            GetComponent<PageChange>().ChangePage();
    }

}
