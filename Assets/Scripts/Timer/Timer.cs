using UnityEngine;
using System;
using System.Collections;

public class Timer : MonoBehaviour {

    protected string currentTime;

    public string GetCurrentTimer()
    {
        return currentTime;
    }

	public void StartTimer(float timeLimit, Action callback)
    {
        StartCoroutine(TimerCoroutine(timeLimit, callback));
    }

    IEnumerator TimerCoroutine(float timeLimit, Action callback)
    {
        yield return new WaitForSeconds(timeLimit);
        if(callback != null)
        {
            callback();
        }
        GameObject.Destroy(gameObject);
    }

    IEnumerator CountOn(float timeLimit, Action callback)
    {
        float counter = 0;
        while(counter < timeLimit)
        {
            counter += Time.deltaTime;
            currentTime = ((int)counter).ToString("00");
            yield return new WaitForEndOfFrame();
        }
        if(callback != null)
        {
            callback();
        }
        GameObject.Destroy(gameObject);
    }
}
