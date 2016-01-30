﻿using UnityEngine;
using System.Collections;

public delegate void OnEvent();

public class BatLife : MonoBehaviour {

    public float points;
    public bool canHitAgain = true;
    public OnEvent onDamage;
    

    public void ListenForHit(Vector3 position)
    {
        if (canHitAgain)
        {
            points += 1;
            if(points == 2)
            {

            }
            if (onDamage != null)
            {
                onDamage();
            }
            canHitAgain = false;
            if (points == 2)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
