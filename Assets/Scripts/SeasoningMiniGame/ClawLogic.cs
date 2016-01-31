using UnityEngine;
using System.Collections;

public class ClawLogic : MonoBehaviour {
    MovementController clawController;
    float displacementSpeed;
    Vector3 lastPosition;
    public ParticleSystem ps;
    public bool trackX, trackY;
    public GameBounds gameBounds;
    public bool justHit = false;
	// Use this for initialization
	void Start () {
        clawController = MovementController.CreateWithDefaultBindings();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 touchPosition = transform.position + clawController.Move;
        Vector3 newPos = Vector3.Lerp(transform.position, new Vector3(trackX ? touchPosition.x : transform.position.x, trackY ? touchPosition.y : transform.position.y, transform.position.z), Time.deltaTime * 20.0f);

        if (clawController.Move.IsPressed && newPos.x < gameBounds.transform.position.x + gameBounds.transform.localScale.x*0.5f && newPos.x > gameBounds.transform.position.x - gameBounds.transform.localScale.x *0.5f )
        {
            transform.position = newPos;
            displacementSpeed = (((transform.position - lastPosition).magnitude) / Time.deltaTime);
            lastPosition = transform.position;
            ps.transform.position = transform.position;
        }
        else {
            displacementSpeed = 0;
        }

	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Grater") && justHit == false)
        {
            justHit = true;
            ps.emissionRate = displacementSpeed*3f;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Equals("Grater") && displacementSpeed > 0)
        {
            Camera.main.SendMessage("DoCameraShake", 0.2f);
            GetComponent<SoundLoader>().PlaySound(Random.Range(0,2));
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        justHit = false;
        displacementSpeed = 0;
        ps.emissionRate = displacementSpeed;
    }
}
