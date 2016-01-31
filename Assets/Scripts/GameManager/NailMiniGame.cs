﻿using UnityEngine;
using System.Collections;

public class NailMiniGame : MiniGameManager
{

    public override void InitGame()
    {
        Debug.Log("Nail Goat");
        TimeClassManager.StartTimer(10, Finished);
    }


    public void Finished()
    {

        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        GameManager.instance.ChooseFirstGame();
    }
}
