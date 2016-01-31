using UnityEngine;
using System.Collections;

public class MiniGameManager : MonoBehaviour {
    public int gamePoints;
    public MovementController move;
    protected bool started = false;
    protected bool endGame = false;
	// Use this for initialization
    public virtual void Start()
    {
        move = MovementController.CreateWithDefaultBindings();
        GameManager.instance.currentMiniGame = this;
	}
	
	// Update is called once per frame
	public virtual void Update () 
    {
        if(move.Start.WasPressed||Input.GetKeyDown(KeyCode.Return))
            GameManager.instance.ChooseFirstGame();
	}

    public virtual void InitGame()
    { 
    
    }

    public virtual void FinalizeGame()
    { 
    
    }
}
