using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject scenesTransitionPrefab;
    
    [SerializeField]    // show private variable on inspector
    private ScenesTransition st;

    void Awake()
    {
        GameObject temp;
        st = GameObject.FindObjectOfType<ScenesTransition>();
        if (st == null)
        {
            temp = Instantiate(scenesTransitionPrefab);
            temp.name = scenesTransitionPrefab.name;
            st = temp.GetComponent<ScenesTransition>();
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
    
}
