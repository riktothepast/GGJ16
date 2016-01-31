using UnityEngine;
using System.Collections;

public class SoundLoader : MonoBehaviour {
    public AudioClip [] sound;

	public void PlaySound (int index) {
        AudioManager.instance.PlaySound(sound[index]);
	}

}