using UnityEngine;
using System.Collections;

public class MiniGameManager : MonoBehaviour {
    public int gamePoints;

	// Use this for initialization
    public virtual void Start()
    {
        GameManager.instance.currentMiniGame = this;
	}
	
	// Update is called once per frame
	public virtual void Update () 
    {
	
	}

    public virtual void InitGame()
    { 
    
    }

    public virtual void FinalizeGame()
    { 
    
    }
}
