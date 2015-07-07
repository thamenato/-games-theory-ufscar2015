using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//! Plays an AudioClip.
/*!
 * Contains two methods that can be used in a Button during the Mouse Hover Event, 
 * to play a sound defined at the public variable buttonSound on Inspector.
 * It requires to be used by an EvenTrigger.
 */
public class ButtonSound : MonoBehaviour {

    // sound to be played when mouse hover
    public AudioClip buttonSound; /*!< Sound that will be played. */

    //! If button sound isn't defined, print the error message at the console.
    void Start()
    {
        if (buttonSound == null)
            Debug.LogError("ButtonSound at " + this.name + " : no sound defined.");
    }

    //! Play the sound defined.
    /*! This is used in most cases, any ordinary button that will play a sound when mouse hover.*/
    public void playSound()
    {
        if(buttonSound != null)
            AudioSource.PlayClipAtPoint(buttonSound, Vector3.one);
    }

    //! Play the sound defined during the Pause Menu.
    /*! This method shall only be used for the Pause Menu when Time.timeScale is being used, 
     * this works as workaround so the sound can be played. */
    public void playSoundPauseMenu()
    {
        if (buttonSound != null)
        {
            // shitty solution to play sounds at the Pause Menu, but well.. it works!
            Time.timeScale = 1;
            AudioSource.PlayClipAtPoint(buttonSound, Vector3.one);
            Time.timeScale = 0;
        }
    }

}
