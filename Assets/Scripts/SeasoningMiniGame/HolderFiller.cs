using UnityEngine;
using System.Collections;

public class HolderFiller : MonoBehaviour {
    public ProgressSlider pogressSlider;
    public int mid = 10;
    public float xCenter = 0f;
    RightMovementController clawController;
    public SpriteRenderer interior;
    public bool trackX, trackY;
    public GameBounds gameBounds;
    void Start()
    {
        clawController = RightMovementController.CreateWithDefaultBindings();
        interior.transform.localScale = Vector3.zero;
    }

    public void InitMovement()
    { 
        
    }


    void OnParticleCollision(GameObject other)
    {
        pogressSlider.currentLife++;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 touchPosition = transform.position + clawController.Move;
        Vector3 newPos = Vector3.Lerp(transform.position, new Vector3(trackX ? touchPosition.x : transform.position.x, trackY ? touchPosition.y : transform.position.y, transform.position.z), Time.deltaTime * 20.0f);

        if (clawController.Move.IsPressed && newPos.x < gameBounds.transform.position.x + gameBounds.transform.localScale.x * 0.5f && newPos.x > gameBounds.transform.position.x - gameBounds.transform.localScale.x * 0.5f)
        {
            transform.position = newPos;
        }*/
        float scale = Mathf.Clamp(pogressSlider.currentLife / pogressSlider.totalLife, 0, 1);
        interior.transform.localScale = new Vector3(scale,scale, scale);
    }
}
