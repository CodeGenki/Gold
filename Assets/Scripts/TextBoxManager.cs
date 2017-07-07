using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public PlayerMovement player;

    public bool isActive;
    public bool stopPlayerMovement;
    public bool isSelection;
    public ActivateTextAtLine activate;
    public SelectionManager selection;

    public bool isDoneTalking;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
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

    private void FixedUpdate()
    {
        if (!isActive)
        {
            return;
        }
        if (textLines[currentLine] == "@\r")
        {
            selection.startSelection = true;
        }
        else
            theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
        }
        if(currentLine > endAtLine)
        {
            isDoneTalking = true;
            DisableTextBox();
            if(activate != null)
                activate.busyChat = false;
            Debug.Log("At end of speech");
        }
    }

    public void EnableTextBox()
    {
        isDoneTalking = false;
        isActive = true;
        textBox.SetActive(true);
        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
    }

    public void DisableTextBox()
    {
        isActive = false;
        textBox.SetActive(false);
        if(player != null)
            player.canMove = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
