﻿using UnityEngine;
using System.Collections;
public class PageChange : MonoBehaviour {

    public int PageToChange;
    public bool useFader = false;
    public KeyCode code;
    MovementController move;
    void Awake()
    {
        move = MovementController.CreateWithDefaultBindings();
    }

	// Update is called once per frame
	void Update () {
        if (move.Start.WasPressed || Input.GetKeyDown(code))
        {
            Debug.Log("page change");
            ChangePage();
        }
	}

    public void ChangePage()
    {
        if (useFader)
        {
            GameObject.FindGameObjectWithTag("Fader").GetComponent<SceneFade>().EndScene(PageToChange);
        }
        else
        {
            Application.LoadLevel(PageToChange);
        }
    }
}
