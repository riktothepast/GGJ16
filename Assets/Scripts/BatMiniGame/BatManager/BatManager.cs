using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BatManager : MonoBehaviour {

    public BatMovement BatMovement;
    public BatMovement fatBat;

    public float rate;
    public int max;
    public float launchPower;

    public void StartUp()
    {
        StartCoroutine(Spawner());
    }

    public void LaunchBat()
    {
        BatMovement bat = null;
        int dran = Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7);
        if(dran < 14)
        {
            bat = (BatMovement)GameObject.Instantiate(BatMovement, transform.position, Quaternion.identity);

        }
        else
        {
            bat = (BatMovement)GameObject.Instantiate(fatBat, transform.position, Quaternion.identity);

        }
        int Rand = Random.Range(0, 3);
        Vector2 power = Vector2.one;
        switch(Rand)
        {
            case 0: power.x = launchPower*Random.Range(0.5f,1f);  break;
            case 1: power.x = launchPower; power.y = launchPower * 0.1f * -1; break;
            case 2: power.x = launchPower; power.y = launchPower * 0.1f ; break;
        }
        bat.Launch(power);
    }

    public void StopManager()
    {
        StopAllCoroutines();
    }

    IEnumerator Spawner()
    {
        while(true)
        {
                LaunchBat();
            yield return new WaitForSeconds(rate);
        }
    }
}
