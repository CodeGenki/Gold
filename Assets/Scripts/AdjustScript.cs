using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10, 100, 100, 30), "Gold up"))
        {
            GameControl.control.gold += 10;
        }
        if (GUI.Button(new Rect(10, 140, 100, 30), "Gold down"))
        {
            GameControl.control.gold -= 10;
        }
        if (GUI.Button(new Rect(10, 180, 100, 30), "EXP up"))
        {
            GameControl.control.exp += 10;
        }
        if (GUI.Button(new Rect(10, 220, 100, 30), "EXP down"))
        {
            GameControl.control.exp -= 10;
        }
        if (GUI.Button(new Rect(10, 260, 100, 30), "Save"))
        {
            GameControl.control.Save();
        }
        if (GUI.Button(new Rect(10, 300, 100, 30), "Load"))
        {
            GameControl.control.Load();
        }
    }
}
