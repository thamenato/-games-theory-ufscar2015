using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject scenesTransitionPrefab;
    
    private ScenesTransition st;
    private bool stopped = false;
    private GameObject player;
    private GameObject pauseMenu;

    void Awake()
    {
        stopped = false;
        player = GameObject.Find("Player");
        pauseMenu = GameObject.Find("pauseMenu");
        GameObject temp;
        st = GameObject.FindObjectOfType<ScenesTransition>();
        if (st == null)
        {
            temp = Instantiate(scenesTransitionPrefab);
            temp.name = scenesTransitionPrefab.name;
            st = temp.GetComponent<ScenesTransition>();
        }
        if (player == null)
            Debug.LogError("GameManager : couldnt find player.");
        if (pauseMenu == null)
            Debug.LogError("GameManager : couldnt find pauseMenu.");
        
        pauseMenu.SetActive(false); // make sure "pauseMenu" is disabled
    }

    void Update()
    {
        // Pause de Game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    public void setLastLoadedScene(string scene)
    {
        st.lastLoadedScene = scene;
    }

    public string getLastLoadedScene() 
    {
        return st.lastLoadedScene;
    }

    public void pauseGame()
    {
        stopped = !stopped;
        if (stopped)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        player.SendMessage("pauseAnimation", !stopped);

        pauseMenu.SetActive(!stopped);
    }
    
}
