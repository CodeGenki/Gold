using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;   // Writing to binary files
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public int gold = 0;
    public int exp = 0;
    public int atk = 0;
    public int def = 0;
    public int level = 0;

	// Use this for initialization
	void Start () {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
	}

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Gold: " + gold);
        GUI.Label(new Rect(10, 40, 100, 30), "EXP: " + exp);

    }
    // Update is called once per frame
    void Update () {
		
	}

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.gold = gold;
        data.exp = exp;
        data.atk = atk;
        data.def = def;
        data.level = level;

        bf.Serialize(file, data);   // Write container to file
        file.Close();
    }


    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open) ;
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            gold = data.gold;
            exp = data.exp;
            atk = data.atk;
            def = data.def;
            level = data.level;
        }
        else
        {
            Debug.Log("No save data exists.");
        }
    }
}

[Serializable]
class PlayerData    // Container class
{
    public int gold;
    public int exp;
    public int atk;
    public int def;
    public int level;
}
