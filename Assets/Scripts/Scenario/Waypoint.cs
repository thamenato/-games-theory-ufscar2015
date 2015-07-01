using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

    public string waypointDescription;  // will be shown in interactionPanel
    public string sceneNameToGo;
    private GameObject interactionPanel;

    void Start()
    {
        interactionPanel = GameObject.Find("InteractionPanel");
        if (interactionPanel == null)
            Debug.LogError("Waypoint : InteractionPanel not found. Maybe wrong name?");
    }

    void Update()
    {
        // get action button - space or return
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
        {
            changeScene();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // activate method 'ShowInteractivePanel' from InteractionPanel
            interactionPanel.SendMessage("ShowInteractivePanel", waypointDescription);
            Debug.Log("Waypoint: " + waypointDescription);
        }
    }

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
        try
        {
            Application.LoadLevel(sceneNameToGo);
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }
    }

}
