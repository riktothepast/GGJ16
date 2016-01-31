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
            SceneManager.LoadScene("ResultPage");
        }
    }


    public void Finished()
    {
        BrainLogic m = GameObject.FindObjectOfType<BrainLogic>();
        if(m.nirvadad == true)
        {
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

