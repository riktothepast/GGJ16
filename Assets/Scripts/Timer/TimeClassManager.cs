using UnityEngine;
using System;
using System.Collections;

public static class TimeClassManager  {

    public static void StartTimer(float timeLimit, Action callback)
    {
        GameObject tempGameObject = new GameObject("Timer");
        Timer timer = tempGameObject.AddComponent<Timer>();
        timer.StartTimer(timeLimit, callback);
    }

}
