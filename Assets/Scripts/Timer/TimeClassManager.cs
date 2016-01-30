using UnityEngine;
using System;
using System.Collections;

public static class TimeClassManager  {

    /// <summary>
    /// Check if null 
    /// </summary>
    public static Timer currentTimer;

    /// <summary>
    /// Call this to start a timer
    /// </summary>
    /// <param name="timeLimit"></param>
    /// <param name="callback"></param>
    public static void StartTimer(float timeLimit, Action callback)
    {
        if (TimeClassManager.currentTimer == null)
        {
            GameObject tempGameObject = new GameObject("Timer");
            TimeClassManager.currentTimer = tempGameObject.AddComponent<Timer>();
            TimeClassManager.currentTimer.StartTimer(timeLimit, callback);
        }
    }

}
