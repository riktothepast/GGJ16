using UnityEngine;
using System.Collections;

public class NailMiniGame : MiniGameManager
{
    public GameObject instructions;

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
