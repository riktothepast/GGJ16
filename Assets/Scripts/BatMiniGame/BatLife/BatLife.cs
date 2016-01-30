using UnityEngine;
using System.Collections;

public delegate void OnEvent();

public class BatLife : MonoBehaviour {

    public float points;

    public OnEvent onDamage;

    public void ListenForHit(Vector3 position)
    {
        float distance = Vector3.Distance(transform.position, position);
        points += Mathf.Clamp(10 - distance, 0, 10);
        Debug.Log(distance);

    }
}
