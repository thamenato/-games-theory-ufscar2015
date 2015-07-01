using UnityEngine;
using System.Collections;

public class ScenesTransition : MonoBehaviour {

    public string lastLoadedScene = "";

	void Start () {
        DontDestroyOnLoad(this.gameObject);
        lastLoadedScene = Application.loadedLevelName;
	}

}
