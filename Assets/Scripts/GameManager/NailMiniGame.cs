using UnityEngine;
using System.Collections;

public class NailMiniGame : MiniGameManager
{
    public GameObject instructions;
    public GameObject endInstructions;


    public override void InitGame()
    {
        
    }

    public override void Update()
    {
        if(started == false && move.Start.WasPressed)
        {
            started = true;
            TimeClassManager.StartTimer(10, Finished);
            instructions.gameObject.SetActive(false);
        }

        if (endGame == true && move.Start.WasPressed)
        {
            GameManager.instance.ChooseFirstGame();
        }
    }

    public void Finished()
    {
        endInstructions.gameObject.SetActive(true);
        endGame = true;
    }

}
