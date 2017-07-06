using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;
    public SelectionManager selection;

    // Use this for initialization
    void Start () {
        //theTextBox = FindObjectOfType<TextBoxManager>();
        selection.startSelection = true;
    }
	
	// Update is called once per frame
	void Update () {
        //theTextBox.ReloadScript(theText);
        //theTextBox.currentLine = startLine;
        //theTextBox.endAtLine = endLine;
        //theTextBox.EnableTextBox();
    }
}
