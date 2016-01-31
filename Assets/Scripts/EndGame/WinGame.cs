using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinGame : MonoBehaviour {

    public SoundLoader sound;
    public float returTIme;
	// Use this for initialization
	void Start () {
        sound.PlaySound(0);
	}
	
	// Update is called once per frame
	void ReturnToStart () {
        SceneManager.LoadScene("MainMenu");
	}
}
