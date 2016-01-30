using UnityEngine;
using System.Collections;

public class HolderFiller : MonoBehaviour {
    public ProgressSlider pogressSlider;

	// Update is called once per frame
	void Update () {
	
	}

    void OnParticleCollision(GameObject other)
    {
        pogressSlider.currentLife++;
    }
}
