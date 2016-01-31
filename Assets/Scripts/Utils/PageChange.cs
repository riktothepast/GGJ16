using UnityEngine;
using System.Collections;
public class PageChange : MonoBehaviour {

    public int PageToChange;
    public bool useFader = false;
    public KeyCode code;
    protected MovementController move;

    void Start()
    {
        move = MovementController.CreateWithDefaultBindings();
    }

	// Update is called once per frame
	void Update () {
        if (move.AButton.IsPressed)
        {
            Debug.Log("Button Pressed");
            ChangePage();
        }
	}

    public void ChangePage()
    {
        if (useFader)
        {
            GameObject.FindGameObjectWithTag("Fader").GetComponent<SceneFade>().EndScene(PageToChange);
        }
        else
        {
            Application.LoadLevel(PageToChange);
        }
    }
}
