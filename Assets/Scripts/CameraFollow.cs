﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //public Transform target;
    public GameControl player;
    public float m_speed = 0.1f;
    private Camera myCam;

	// Use this for initialization
	void Start () {
        myCam = GetComponent<Camera>();
        //target = FindObjectOfType<Transform>();
        player = FindObjectOfType<GameControl>();
	}
	
	// Update is called once per frame
	void Update () {
        myCam.orthographicSize = (Screen.height / 100f) / 2f;   // Maintains same scale across all devices

        if (player)
        {
            transform.position = Vector3.Lerp(transform.position, player.playerPosition, m_speed) + new Vector3(0, 0, -10);            
        }
	}
}
