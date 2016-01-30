using UnityEngine;
using System;
using System.Collections;

public class Timer : MonoBehaviour {

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
}
