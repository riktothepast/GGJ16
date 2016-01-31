﻿using UnityEngine;
using System.Collections;

public class HolderFiller : MonoBehaviour {
    public ProgressSlider pogressSlider;
    public int mid = 10;
    public float xCenter = 0f;
    RightMovementController clawController;
    public SpriteRenderer interior;
    public bool trackX, trackY;
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
        if (clawController.Move.IsPressed)
        {
            Vector3 touchPosition = transform.position + new Vector3(-clawController.Move.X, -clawController.Move.Y, 0);
            transform.position = Vector3.Lerp(transform.position, new Vector3(trackX ? touchPosition.x : transform.position.x, trackY ? touchPosition.y : transform.position.y, transform.position.z), Time.deltaTime * 20.0f);
        }
        float scale = Mathf.Clamp(pogressSlider.currentLife / pogressSlider.totalLife, 0, 1);
        interior.transform.localScale = new Vector3(scale,scale, scale);
    }
}
