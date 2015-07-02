using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour {

    // sound to be played when mouse hover
    public AudioClip buttonSound;

    void Start()
    {
        if (buttonSound == null)
            Debug.LogError("ButtonSound at " + this.name + " : no sound defined.");
    }

    public void playSound()
    {
        AudioSource.PlayClipAtPoint(buttonSound, Vector3.one);
    }

}
