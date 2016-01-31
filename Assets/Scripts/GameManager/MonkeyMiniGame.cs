using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MonkeyMiniGame : MiniGameManager {

    public GameObject instructions;
    public GameObject endInstructions;


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
        endInstructions.gameObject.SetActive(true);
        endGame = true;
    }

}

