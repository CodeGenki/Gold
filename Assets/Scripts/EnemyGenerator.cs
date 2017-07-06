using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class EnemyGenerator : MonoBehaviour {

    public static EnemyGenerator enemyControl;

    public int level = 0;
    public int atk = 0;
    public int def = 0;
    public int hp = 0;
    private System.Random rand;
    private bool readyForBattle;

    public enum EnemySprite
    {
        one,
        two,
        three
    }
    public EnemySprite sprite;
	// Use this for initialization
	void Start () {
        if (enemyControl == null)
        {
            DontDestroyOnLoad(gameObject);
            enemyControl = this;
        }
        else if (enemyControl != this)
        {
            Destroy(gameObject);
        }
        rand = new System.Random();
	}
	
	// Update is called once per frame
	void Update () {
        if (readyForBattle)
        {
            int x = rand.Next(100);
            if (x >= 0 && x < 2)   //2% chance for battle per frame
            {
                
                level = (int)(GameControl.control.level * (rand.NextDouble() + 0.5) * 1.5f);
                atk = (int)(((rand.NextDouble()) + 1) * 5 * level);
                def = (int)(((rand.NextDouble()) + 1) * 2 * level);
                hp = (int)(((rand.NextDouble()) + 1) * 30 * level);
                readyForBattle = false;
                sprite = (EnemySprite)rand.Next(3);
                EnterBattleScene();
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            readyForBattle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            readyForBattle = false;
        }
    }

    private void EnterBattleScene()
    {
        SceneManager.LoadScene(1);
    }
}
