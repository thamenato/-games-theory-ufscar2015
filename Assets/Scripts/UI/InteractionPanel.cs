using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractionPanel : MonoBehaviour {

    private Text interactionText;
    private Image panel;

	// Use this for initialization
	void Start () {
        // get all component
        interactionText = GetComponentInChildren<Text>();
        panel = GetComponent<Image>();
        // verify components
        if (interactionText == null)
            Debug.LogError("CanvasUI.InteractionPanel : Text not found in children");
        if(panel == null)
            Debug.LogError("CanvasUI.InteractionPanel : Image not found");
        
        // set-up
        interactionText.color = new Color(255f, 255f, 255f, 0f); // opacity 0
        panel.color = new Color(255f, 255f, 255f, 0f);
        interactionText.enabled = false; // disable component
        panel.enabled = false;
    }

    void ShowInteractivePanel(string interaction)
    {
        interactionText.text = interaction;
        // TODO: Implementar animacao de transicao em interaction panel
        interactionText.color = new Color(255f, 255f, 255f, 1f); // opacity 0
        panel.color = new Color(255f, 255f, 255f, 0.1f);
        interactionText.enabled = true; // disable component
        panel.enabled = true;
    }

    void HideInteractivePanel()
    {
        // TODO: Implementar animacao de transicao para desaparecer panel
        interactionText.color = new Color(255f, 255f, 255f, 0f); // opacity 0
        panel.color = new Color(255f, 255f, 255f, 0f);
        interactionText.enabled = false; // disable component
        panel.enabled = false;
    }
}
