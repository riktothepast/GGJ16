using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BatManager : MonoBehaviour {

    public BatMovement BatMovement;

    public float rate;
    public int max;
    public float launchPower;
    
    void Start()
    {
        StartCoroutine(Spawner());
    }

    public void LaunchBat()
    {
        BatMovement bat = (BatMovement)GameObject.Instantiate(BatMovement, transform.position, Quaternion.identity);
        int Rand = Random.Range(0, 3);
        Vector2 power = Vector2.one;
        switch(Rand)
        {
            case 0: power.x = launchPower*0.7f;  break;
            case 1: power.x = launchPower; power.y = launchPower * 0.1f * -1; break;
            case 2: power.x = launchPower; power.y = launchPower * 0.1f ; break;
        }
        bat.Launch(power);
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
