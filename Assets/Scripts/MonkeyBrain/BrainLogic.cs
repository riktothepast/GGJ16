using UnityEngine;
using System.Collections;
using InControl;

public class BrainLogic : MonoBehaviour {
    Rigidbody2D rb;
    float lastAngle;
    float push = 2f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Abs((lastAngle - InputManager.ActiveDevice.LeftStick.Angle) / Time.deltaTime)>1000)
        {
            rb.AddForce(Vector2.up * push, ForceMode2D.Impulse);
        }
        Debug.Log((lastAngle - InputManager.ActiveDevice.LeftStick.Angle) / Time.deltaTime );

        lastAngle = InputManager.ActiveDevice.LeftStick.Angle;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up *2f, ForceMode2D.Impulse);
        }
	}
}
