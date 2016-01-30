using UnityEngine;
using System.Collections;

public class ObjectRecycler : MonoBehaviour {
    public float ttl;

	// Use this for initialization
	void OnEnable () {
        if(ttl > 0)
            Invoke("Clear", ttl);
	}

    public void Clear()
    {
        this.gameObject.Recycle();
    }
}