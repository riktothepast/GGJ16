using UnityEngine;
using System.Collections;

public class ClawLogic : MonoBehaviour {
    MovementController clawController;
    float displacementSpeed;
    Vector3 lastPosition;
    public ParticleSystem ps;
    public bool trackX, trackY;
	// Use this for initialization
	void Start () {
        clawController = MovementController.CreateWithDefaultBindings();
	}
	
	// Update is called once per frame
	void Update () {
        if (clawController.Move.IsPressed)
        {
            Vector3 touchPosition = transform.position + clawController.Move;
            transform.position = Vector3.Lerp(transform.position, new Vector3(trackX ? touchPosition.x : transform.position.x, trackY ? touchPosition.y : transform.position.y, transform.position.z), Time.deltaTime * 20.0f);
            displacementSpeed = (((transform.position - lastPosition).magnitude) / Time.deltaTime);
            lastPosition = transform.position;
            ps.transform.position = transform.position;
        }
        else {
            displacementSpeed = 0;
        }

	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Equals("Grater"))
        {
            ps.emissionRate = displacementSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        displacementSpeed = 0;
        ps.emissionRate = displacementSpeed;
    }
}
