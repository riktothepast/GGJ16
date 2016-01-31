﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IntroChanger : MonoBehaviour {
    public List<string> dialogues;
    public List<Sprite> sprites;
    public Image img;
    public Text text;
    int currentIndex = -1;
    public float timeToChage = 1f;
	// Use this for initialization
	void Start () {
        img.color = Color.black;
        text.color= Color.white;
        currentIndex = 0;
        if (sprites.Count > 0 && sprites.Count > currentIndex )
        {
            img.sprite = sprites[currentIndex];
        }
        text.text = dialogues[currentIndex];
        Invoke("MoveToNextData", 1f);
	}

    void MoveToNextData()
    {
        StartCoroutine(FadeCurrentData());
    }

    IEnumerator FadeCurrentData()
    {
        while (text.color.a > 0.1f)
        {
            text.color = Color.Lerp(text.color, Color.clear, Time.deltaTime*timeToChage);
            img.color = Color.Lerp(img.color, Color.black, Time.deltaTime * timeToChage);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        StartCoroutine(ShowCurrentData());
    }

    IEnumerator ShowCurrentData()
    {
        currentIndex++;
        if (currentIndex < dialogues.Count)
        {
            if(sprites.Count > currentIndex)
                img.sprite = sprites[currentIndex];
            text.text = dialogues[currentIndex];

            while (text.color.a < 0.95f)
            {
                text.color = Color.Lerp(text.color, Color.white, Time.deltaTime * timeToChage);
                img.color = Color.Lerp(img.color, Color.black, Time.deltaTime * timeToChage);
                yield return new WaitForSeconds(Time.deltaTime);

            }
        }
        if (currentIndex < dialogues.Count)
            MoveToNextData();
        else
            if (GetComponent<PageChange>())
                GetComponent<PageChange>().ChangePage();
    }

}
