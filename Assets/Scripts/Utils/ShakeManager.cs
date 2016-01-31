using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class ShakeManager : MonoBehaviour {
    CameraShakeTween shake;

	void Start () {
        shake = new CameraShakeTween(Camera.main);
	}

    void DoCameraShake(float intensity = 10f)
    { 
         shake.shake(intensity);
         Debug.Log("shake");
    }
}
