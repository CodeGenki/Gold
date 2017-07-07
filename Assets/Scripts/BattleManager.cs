using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

    public TextAsset atkText;
    public TextAsset enemyAtkText;
    public TextAsset generalText;

    public int startLine;
    public int endLine;

    //public TextBoxManager theTextBox;
    public SelectionManager atkType;
    public SelectionManager skillType;

    private GameControl player;
    private EnemyGenerator enemy;

    public bool playerTurn;
    public bool enemyTurn;

    public bool enemyIsDead;
    public bool playerIsDead;

    private bool playerMakeMove;

    public TextBoxManager textBox2;

    // Use this for initialization
    void Start () {
        atkType.startSelection = true;
        player = FindObjectOfType<GameControl>();
        enemy = FindObjectOfType<EnemyGenerator>();
        playerTurn = true;
        startLine = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (playerTurn && enemy.hp > 0 && player.gold >= 0 && !textBox2.isActive)
        {
            textBox2.ReloadScript(generalText);
            textBox2.currentLine = startLine;
            textBox2.endAtLine = endLine;
            textBox2.EnableTextBox();
            playerTurn = false;
            Debug.Log("Player turn started");
            atkType.startSelection = true;
            playerMakeMove = true;
        }
        if (playerMakeMove)
        {
            if (atkType.selectionComplete)
            {
                Debug.Log("Selection complete.");
                if (atkType.chosen == 0)       // Regular attack
                {
                    atkType.selectionComplete = false;
                    playerMakeMove = false;
                    Debug.Log("ATTACK");
                    playerTurn = false;
                    textBox2.ReloadScript(atkText);
                    textBox2.currentLine = startLine;
                    textBox2.endAtLine = endLine;
                    textBox2.EnableTextBox();
                    // atk animation
                    if (player.atk >= enemy.def)
                        enemy.hp -= player.atk - enemy.def;
                    else
                        enemy.hp--;
                    enemyTurn = true;
                }
                else if (atkType.chosen == 1)
                {
                    atkType.selectionComplete = false;
                    playerMakeMove = false;
                    playerTurn = false;
                    skillType.startSelection = true;
                    if (skillType.startSelection == false)
                    {
                        // do selection stuff here
                    }
                    enemyTurn = true;
                }
                else if (atkType.chosen == 2)
                {
                    atkType.selectionComplete = false;
                    playerMakeMove = false;
                    playerTurn = false;
                    // send message and change scene
                    //Debug.Log("Here");
                    SceneManager.LoadScene(0);
                }
            }
        }
        if (enemy != null && enemy.hp <= 0)
        {
            // message that you defeated enemy.
            player.exp += (enemy.level * 8);
            SceneManager.LoadScene(0);
        }
        if (player != null && player.gold < 0)
        {
            // game over
            playerIsDead = true;
            textBox2.DisableTextBox();
            atkType.DisableTextBox();
            Debug.Log("Player died.");
        }

        if (enemyTurn && enemy.hp > 0)
        {
            Debug.Log("Enemy turn started");
            // Do attack animation
            textBox2.ReloadScript(enemyAtkText);
            textBox2.currentLine = startLine;
            textBox2.endAtLine = endLine;
            textBox2.EnableTextBox();
            if (enemy.atk - player.def > 0)
                player.gold -= (enemy.atk - player.def);
            else
                player.gold -= 1;
            enemyTurn = false;
            playerTurn = true;
        }
        if(enemy != null && enemy.hp <= 0)
        {
            // Die animation
            enemyIsDead = true;
            Debug.Log("Enemy died.");
        }
    }
}
