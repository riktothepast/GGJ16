using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PageChange : MonoBehaviour {

    public int PageToChange;
    public bool useFader = false;
    public KeyCode code;
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(code)))
        {
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
            SceneManager.LoadScene(PageToChange);
    }
}
