using UnityEngine;
using System.Collections;
using InControl;

public class BrainLogic : MonoBehaviour {
    Rigidbody2D rb;
    float lastAngle;
    public float push = 2f;
    ParticleSystem ps;
    SoundLoader soundLoader;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponentInChildren<ParticleSystem>();
        soundLoader = GetComponent<SoundLoader>();
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
        if (rb.velocity != Vector2.zero)
        {
            ps.emissionRate = 50;
            soundLoader.PlaySound(1);
        }
        else {
            ps.emissionRate = 0;
            soundLoader.PlaySound(0);
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
