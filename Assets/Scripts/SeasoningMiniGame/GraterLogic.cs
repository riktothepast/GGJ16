using UnityEngine;
using System.Collections;

public class GraterLogic : MonoBehaviour
{
    RightMovementController clawController;
    public bool trackX, trackY;
    public float xCenter = 0;
    public float xRange = 2;
    public float invokeSpeed = 3f;
    public GameBounds gamebounds;
    public HolderFiller holder;
    // Use this for initialization

    void Start()
    {
        InvokeRepeating("NewPosition", invokeSpeed, invokeSpeed);
    }

    public void NewPosition()
    {
        transform.position = new Vector3(Random.Range(-gamebounds.transform.localScale.x *0.5f, gamebounds.transform.localScale.x * 0.5f), transform.position.y, transform.position.z);
        holder.transform.position = transform.position;
    }

}
