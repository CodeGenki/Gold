using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour {

    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;
    public GameObject textBox;
    public PlayerMovement player;
    public bool isActive;
    public bool startSelection;
    public int selectedItem;
    public int chosen;
    public bool selectionComplete;

    public enum SelectionModes
    {
        battle,
        yesno,
    }

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerMovement>();
        player = FindObjectOfType<PlayerMovement>();
        selectedItem = 0;

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (startSelection)
        {
            EnableTextBox();
            string[] text = new string[textLines.Length];
            string displayText = "";
            for (int i = 0; i < textLines.Length; i++)
            {
                if (selectedItem == i)
                {
                    text[i] = ">" + textLines[i];
                }
                else
                {
                    text[i] = "  " + textLines[i];
                }
                if(i != textLines.Length - 1)
                    displayText += (text[i] + "\n");
                else
                    displayText += (text[i]);
            }
            theText.text = displayText;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selectedItem < textLines.Length - 1)
                    selectedItem++;
                else if (selectedItem == textLines.Length - 1)
                    selectedItem = 0;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (selectedItem > 0)
                    selectedItem--;
                else if (selectedItem == 0)
                    selectedItem = textLines.Length - 1;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startSelection = false;
                DisableTextBox();
                Debug.Log("Destroyed text box");
                chosen = selectedItem;
                selectedItem = 0;
                DoAction();
                selectionComplete = true;
            }
        }
	}

    public void EnableTextBox()
    {
        isActive = true;
        textBox.SetActive(true);
        if(player != null)
          player.canMove = false;
    }

    public void DisableTextBox()
    {
        isActive = false;
        textBox.SetActive(false);
        if(player != null)
            player.canMove = true;
    }

    public void DoAction()
    {
        Debug.Log("You selected " + textLines[chosen]);
    }

    public void LoadTextFile(string fileName)
    {
        textFile = (TextAsset)Resources.Load(fileName);
    }
}
