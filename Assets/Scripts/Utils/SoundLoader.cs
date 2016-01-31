using UnityEngine;
using System.Collections;

public class SoundLoader : MonoBehaviour {
    public AudioClip [] sound;
    public bool mustWaitForSound;

    void Start()
    {
        AudioManager.instance.mustWaitOnAudioClip = mustWaitForSound;
    }

	public void PlaySound (int index) {
        AudioManager.instance.PlaySound(sound[index]);
	}

}