using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour {

    Slider slider;
    public float totalLife, currentLife;
    bool mustBeUpdated = true;
	// Use this for initialization
	void Awake () {
		slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
       float progress = (float)currentLife / (float) totalLife;
	   slider.value = progress;
       if (currentLife >= totalLife)
       {
           mustBeUpdated = false;
           GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().FinalizeGame();
       }
	}

    public float GetPercent()
    {
        return (float)currentLife / (float)totalLife;
    }
}
