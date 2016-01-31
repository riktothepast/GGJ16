using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MonkeyMiniGame : MiniGameManager {

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
        SceneManager.LoadScene("ResultPage");
    }
}

