using UnityEngine;
using System.Collections;

public delegate void OnEvent();

public class BatLife : MonoBehaviour {

    public float points;
    public bool canHitAgain = true;
    public OnEvent onDamage;
    public OnEvent onDeath;
    
    public void ListenForHit(Vector3 position)
    {
        if (canHitAgain)
        {
            points -= 1;
         
            if (onDamage != null)
            {
                onDamage();
            }
            canHitAgain = false;
            if (points == 0)
            {
                if(onDeath != null)
                {
                    onDeath();
                }
                GameObject.Destroy(gameObject);
            }
        }
    }
}
