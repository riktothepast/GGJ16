using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour {

	Slider slider;
    public float totalLife, currentLife;

	// Use this for initialization
	void Awake () {
		slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
       float progress = (float)currentLife / (float) totalLife;
	   slider.value = progress;
	}
}
