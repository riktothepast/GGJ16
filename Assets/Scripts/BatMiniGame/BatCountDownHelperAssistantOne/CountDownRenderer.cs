using UnityEngine;
using System.Collections;

public class CountDownRenderer : MonoBehaviour {

    public TextMesh textSample;

    void Start()
    {
        textSample = GetComponent<TextMesh>();
    }

    void Update()
    {
        if (TimeClassManager.currentTimer != null)
        {
            textSample.text = TimeClassManager.currentTimer.GetCurrentTimerString();
        }
    }   
}
