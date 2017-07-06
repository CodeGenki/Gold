using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Name the NPC's scripts as the gameObject's name
public class NPC : MonoBehaviour {

    public SelectionManager sel;
    public GameControl player;
    public TextBoxManager textBox;
    public string npcScript;

	// Use this for initialization
	void Start () {
        npcScript = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
        if (sel.selectionComplete)
        {
            if (sel.selectedItem == 0)
            {
                player.gold -= 100;
                textBox.ReloadScript((TextAsset)Resources.Load(npcScript)); // Not quite what I want. What about separating segments of a script by \r
            }
        }
	}
}
