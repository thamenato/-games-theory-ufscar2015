using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

    public string waypointDescription;  // will be shown in interactionPanel
    public string sceneNameToGo;
    private GameObject interactionPanel;
    private GameManager gm;

    void Start()
    {
        interactionPanel = GameObject.Find("InteractionPanel");
        gm = GameObject.FindObjectOfType<GameManager>();
        if (interactionPanel == null)
            Debug.LogError("Waypoint : InteractionPanel not found. Maybe wrong name?");
        if (gm == null)
            Debug.LogError("Waypoint : Couldnt find GameManager.");
    }

    // Show waypointDescription on Canvas - InteractionPanel
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // activate method 'ShowInteractivePanel' from InteractionPanel
            interactionPanel.SendMessage("ShowInteractivePanel", waypointDescription);
            Debug.Log("Waypoint: " + waypointDescription);
        }
    }

    // Accepts input 'action button' to change scene
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // get action button - space or return
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
            {
                if (sceneNameToGo.Length != 0)
                    changeScene();
                else
                    Debug.Log("Waypoint : sceneNameToGo not defined!");
            }
        }
    }

    // Hides waypointDescription on Canvas
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // activate method 'HideInteractivePanel' from InteractionPanel
            interactionPanel.SendMessage("HideInteractivePanel");
            Debug.Log("Waypoint: hide interactive panel");
        }
    }

    void changeScene()
    {
        if(sceneNameToGo.Length != 0) // there is a scene to go to
            try
            {
                gm.setLastLoadedScene(Application.loadedLevelName);
                Application.LoadLevel(sceneNameToGo);
            }
            catch(System.Exception e)
            {
                Debug.LogException(e);
            }
    }

}
