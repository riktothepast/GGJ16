using UnityEngine;
using System;
using System.Collections;

public class Timer : MonoBehaviour {

    protected string currentTime;

    public float _time;

    public string GetCurrentTimerString()
    {
        return currentTime;
    }

    public float GetCurrentTime()
    {
        return _time;
    }

	public void StartTimer(float timeLimit, Action callback)
    {
        StartCoroutine(CountOn(timeLimit, callback));
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
        _time = 0;
        while(_time < timeLimit)
        {
            _time += Time.deltaTime;
            currentTime = ((int)_time).ToString("00");
            yield return new WaitForEndOfFrame();
        }
        if(callback != null)
        {
            callback();
        }
        GameObject.Destroy(gameObject);
        TimeClassManager.currentTimer = null;
    }
}
