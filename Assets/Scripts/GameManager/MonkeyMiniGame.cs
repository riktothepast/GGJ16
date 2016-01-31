using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MonkeyMiniGame : MiniGameManager {

    public GameObject instructions;

    public override void Update()
    {
        if (started == false && move.Start.WasPressed)
        {
            started = true;
            TimeClassManager.StartTimer(10, Finished);
            instructions.gameObject.SetActive(false);
        }
    }


    public void Finished()
    {
    
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("ResultPage");
    }
}

