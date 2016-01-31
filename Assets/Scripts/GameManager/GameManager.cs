using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public int totalPoints, currentPoints;
    int miniGameCount = 0;
    public string[] minigames;
    public MiniGameManager currentMiniGame;
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);

            if (GameObject.FindGameObjectsWithTag("GameManager").Length > 1)
            {
                Destroy(this.gameObject);
                return;
            }
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        InitGame();
    }

    public void ChooseFirstGame()
    {
        reshuffle(minigames);
        SceneManager.LoadScene(minigames[miniGameCount]);
        miniGameCount++;
    }

    public void ChooseNextGame()
    {

    }

    public void InitGame()
    {
        currentMiniGame.InitGame();
    }

    public void FinalizeGame()
    {
        currentMiniGame.FinalizeGame();
    }

    void reshuffle(string[] scenes)
    {
        for (int t = 0; t < scenes.Length; t++)
        {
            string tmp = scenes[t];
            int r = Random.Range(t, scenes.Length);
            scenes[t] = scenes[r];
            scenes[r] = tmp;
        }
    }
}
