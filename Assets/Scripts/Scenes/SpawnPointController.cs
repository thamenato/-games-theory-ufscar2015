using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPointController : MonoBehaviour {

    [Header("Workaround for Dictionary")]
    // Workaround for Dicionary
    [Tooltip("Same element number for Spawn Name and Spawn Point")]
    public List<string> spawnName;
    [Tooltip("Same element number for Spawn Name and Spawn Point")]
    public List<Vector3> spawnPoint;

    // get GameManer, player and camera
    private GameManager gm;
    private Transform player;
    private Transform camera;

	void Start () 
    {
        if (spawnName.Count != spawnPoint.Count)
            Debug.LogError("SpawnPointController : spawnName and spawnPoint have different sizes");
        
        gm = GameObject.FindObjectOfType<GameManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        camera = GameObject.Find("Main Camera").GetComponent<Transform>();

        // verify 
        if (gm == null)
            Debug.LogError("EntranceCorridorController : couldnt find GameManager!");
        if (player == null)
            Debug.LogError("EntranceCorridorController : couldnt find Player!");

        // define current player and camera spawn position
        player.position = spawnPoint[spawnName.IndexOf(gm.getLastLoadedScene())];
        camera.position = new Vector3(player.position.x, camera.position.y, camera.position.z);
    }
	
}
