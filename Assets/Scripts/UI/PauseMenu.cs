using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    private GameManager gm;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        if(gm == null)
            Debug.LogError("PauseMenu : GameManager couldnt be found");
    }

    public void returnToGame()
    {
        gm.pauseGame();
    }

    public void goBackMainMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel("main");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
