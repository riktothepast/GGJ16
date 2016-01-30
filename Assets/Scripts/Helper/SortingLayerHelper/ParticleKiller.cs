using UnityEngine;
using System.Collections;

public class ParticleKiller : MonoBehaviour {

    public ParticleSystem particleSystemd;

	// Use this for initialization
	void Start () {
        particleSystemd = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(!particleSystemd.isPlaying)
        {
            GameObject.Destroy(gameObject);
        }
	}
}
