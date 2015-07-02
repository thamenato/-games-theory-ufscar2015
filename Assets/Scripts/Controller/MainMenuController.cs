using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    public GameObject about;

    void Start()
    {
        about.SetActive(false);
    }

    public void startGame()
    {
        Application.LoadLevel("[1st]entrance_corridor");
    }

    public void setAbout(bool c)
    {
        about.SetActive(c);
    }


}
