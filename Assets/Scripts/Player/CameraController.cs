using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    
    [Range(0.1f, 1.0f)]
    public float smoothTime = 0.5f; // default

    private Transform player;
    private Vector3 velocity;

    // Use this for initialization
	void Start () {
        // Get "Player" Transform component
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (player == null)
            Debug.LogError("Camera error: GameObject Player not found!");
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, // current position
            new Vector3(player.position.x, transform.position.y, transform.position.z), // to this pos 
            ref velocity, // this vel
            smoothTime);    // smooth time set on editor
    }
}
