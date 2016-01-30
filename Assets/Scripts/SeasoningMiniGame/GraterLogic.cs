using UnityEngine;
using System.Collections;

public class GraterLogic : MonoBehaviour
{
    RightMovementController clawController;
    public bool trackX, trackY;
    public float xCenter = 0;
    public float xRange = 2;
    public float invokeSpeed = 3f;
    // Use this for initialization

    void Start()
    {
        InvokeRepeating("NewPosition", invokeSpeed, invokeSpeed);
    }

    public void NewPosition()
    {
        transform.position = new Vector3(xCenter + Random.Range(-xRange, xRange), transform.position.y, transform.position.z);
    }

}
