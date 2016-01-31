using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MonkeyMiniGame : MiniGameManager {

    public GameObject instructions;
    public GameObject endInstructions;

    public Text gameOver;
    public override void Update()
    {
        if (started == false && move.Start.WasPressed)
        {
            started = true;
            TimeClassManager.StartTimer(10, Finished);
            instructions.gameObject.SetActive(false);
        }

        if (endGame == true && move.Start.WasPressed)
        {
            int result = GameManager.instance.game_1 + GameManager.instance.game_2 + GameManager.instance.game_3;
            if (result >= 2)
            {
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                SceneManager.LoadScene("LoseScene");

            }
        }
    }


    public void Finished()
    {
        BrainLogic m = GameObject.FindObjectOfType<BrainLogic>();
        if(m.nirvadad == true)
        {
            GameManager.instance.game_3 = 1;
            gameOver.text = endMessages[1];
        }
        else
        {
            gameOver.text = endMessages[0];

        }
        endInstructions.gameObject.SetActive(true);
        endGame = true;
    }

}

