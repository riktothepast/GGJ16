using UnityEngine;
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
            float distance = Vector3.Distance(transform.position, position);
            points += Mathf.Clamp(30.12f - distance, 0, 0.12f) * 100;
            if (onDamage != null)
            {
                onDamage();
            }
            canHitAgain = false;
        }
    }
}
