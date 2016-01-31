using UnityEngine;
using System.Collections;

public class BatMiniGame : MiniGameManager {

    public BatManager batManager_1;
    public BatManager batManager_2;

    public int batsKilled;
    public int batsReleased;

    public GameObject instructions;

    public override void InitGame()
    {
      
    }

 

    public override void Update()
    {
        if (started == false && move.AButton.WasPressed)
        {
            started = true;
            batManager_1.StartUp();
            StartCoroutine(StartSecondManager());
            TimeClassManager.StartTimer(25, Finished);
            instructions.gameObject.SetActive(false);
        }
    }


    IEnumerator StartSecondManager()
    {
        yield return new WaitForSeconds(7);
        batManager_2.StartUp();
    }

    public void Finished()
    {
        Debug.Log((float)batsKilled / (float)batsReleased);
        Debug.Log("Thats all");
        batManager_1.StopManager();
        batManager_2.StopManager();
        BatMovement[] allBats = GameObject.FindObjectsOfType<BatMovement>();
        for (int i = 0; i < allBats.Length; i++)
        {
            allBats[i].KillBat();
        }
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        GameManager.instance.ChooseFirstGame();
    }

}
