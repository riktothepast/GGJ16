using UnityEngine;
using System;
using System.Collections;

public static class TimeClassManager  {

    public static Timer currentTimer;

    public static void StartTimer(float timeLimit, Action callback)
    {
        GameObject tempGameObject = new GameObject("Timer");
        TimeClassManager.currentTimer = tempGameObject.AddComponent<Timer>();
        TimeClassManager.currentTimer.StartTimer(timeLimit, callback);
    }

}
