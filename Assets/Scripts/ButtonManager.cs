using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    public Button button;

    // Use this for initialization
    void Start () {
        if (button.name == "NewGame")
            button.onClick.AddListener(NewGame);
        else if (button.name == "Continue")
            button.onClick.AddListener(Continue);
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void NewGame()
    {
        Debug.Log("New game has been chosen");        
        SceneManager.LoadSceneAsync(0);
    }

    private void Continue()
    {
        Debug.Log("Continue has been chosen");
        //GameControl.control.Load();
        SceneManager.LoadSceneAsync(0);
    }
}
