using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BatMiniGame : MiniGameManager {

    public BatManager batManager_1;
    public BatManager batManager_2;

    public int batsKilled;
    public int batsReleased;

    public GameObject instructions;
    public GameObject endInstructions;
    public Text gameOver;

    public override void InitGame()
    {
      
    }

    public override void Update()
    {
        if (started == false && move.Start.WasPressed)
        {
            started = true;
            batManager_1.StartUp();
            StartCoroutine(StartSecondManager());
            TimeClassManager.StartTimer(25, Finished);
            instructions.gameObject.SetActive(false);
        }

        if(endGame == true && move.Start.WasPressed)
        {
            GameManager.instance.ChooseFirstGame();
        }
    }


    IEnumerator StartSecondManager()
    {
        yield return new WaitForSeconds(7);
        batManager_2.StartUp();
    }

    public void Finished()
    {
        float per = (float)batsKilled / (float)batsReleased;
        if (per < 0.5f)
        {
            gameOver.text = endMessages[0];
        }
        else if (per >= 0.5f)
        {
            GameManager.instance.game_2 = 1;
            gameOver.text = endMessages[2];
        }

        batManager_1.StopManager();
        batManager_2.StopManager();
        BatMovement[] allBats = GameObject.FindObjectsOfType<BatMovement>();
        for (int i = 0; i < allBats.Length; i++)
        {
            allBats[i].KillBat();
        }
        endInstructions.gameObject.SetActive(true);
        endGame = true;
    }


}
