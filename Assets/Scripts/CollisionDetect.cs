using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour {

    public static PolygonCollider2D collider;
	// Use this for initialization
	void Start () {
        collider = GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static bool hasCollision(Vector3 pos)
    {
        if (collider.OverlapPoint(pos))
        {
            Debug.Log(pos.ToString() + "\n");
            Debug.Log("Collider detected");
            //Bump sound
            return true;
        }
        return false;
    }
}
