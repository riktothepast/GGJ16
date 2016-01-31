using UnityEngine;
using System.Collections;
using InControl;

public class BrainLogic : MonoBehaviour {
    Rigidbody2D rb;
    float lastAngle;
    public float push = 2f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Abs((lastAngle - InputManager.ActiveDevice.LeftStick.Angle) / Time.deltaTime)>750)
        {
            rb.AddForce(Vector2.up * push, ForceMode2D.Impulse);
            Camera.main.SendMessage("DoCameraShake", 0.1f);

        }
        lastAngle = InputManager.ActiveDevice.LeftStick.Angle;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * push, ForceMode2D.Impulse);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Goal"))
        {
            rb.AddForce(Vector2.up * 200, ForceMode2D.Impulse);
            Camera.main.SendMessage("DoCameraShake", 5);
        }
    }
}
