using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NailMiniGame : MiniGameManager
{
    public GameObject instructions;
    public GameObject endInstructions;
    public Text gameOver;
    public HolderFiller holderFilller;

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
        float per = holderFilller.pogressSlider.GetPercent();

        if(per < 0.6f)
        {
            gameOver.text = endMessages[0];
        }
        else if(per >= 0.6f)
        {
            GameManager.instance.game_1 = 1;
            gameOver.text = endMessages[1];
        }

        endInstructions.gameObject.SetActive(true);
        endGame = true;
    }

}
