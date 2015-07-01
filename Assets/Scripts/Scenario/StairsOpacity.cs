using UnityEngine;
using System.Collections;

public class StairsOpacity : MonoBehaviour {

    private SpriteRenderer sprite;
    private float colliderWidth;
    private float startPoint;
    private float endPoint;

	// Use this for initialization
	void Start () {
        colliderWidth = GetComponent<BoxCollider2D>().size.x;
        sprite = GetComponent<SpriteRenderer>();
        startPoint = transform.position.x - colliderWidth / 2;
        endPoint = startPoint + colliderWidth;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            float opacity = (other.transform.position.x - endPoint)/(startPoint - endPoint);
            if (opacity < 0) opacity = 0;
            if (opacity > 1) opacity = 1;
            sprite.color = new Color(sprite.color.r,sprite.color.g, sprite.color.b, opacity);
        }
    }

}
