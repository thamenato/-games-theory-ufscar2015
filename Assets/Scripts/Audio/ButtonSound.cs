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

    public void playSoundPauseMenu()
    {
        // shitty solution to play sounds at the Pause Menu, but well.. it works!
        Time.timeScale = 1;
        AudioSource.PlayClipAtPoint(buttonSound, Vector3.one);
        Time.timeScale = 0;
    }

}
