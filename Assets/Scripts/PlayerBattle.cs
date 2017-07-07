using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBattle : MonoBehaviour {

    public static bool playerTurn;
    private GameControl player;
    private EnemyGenerator enemy;
    public SelectionManager atkType;
    public SelectionManager skillType;

    // Use this for initialization
    void Start () {
        atkType = GetComponent<SelectionManager>();
        skillType = GetComponent<SelectionManager>();
        DontDestroyOnLoad(gameObject);
        player = GetComponent<GameControl>();
        enemy = GetComponent<EnemyGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerTurn && enemy.hp > 0)
        {
            Debug.Log("Player turn started");
            atkType.startSelection = true;
            if(atkType.chosen == 0)       // Regular attack
            {
                // atk animation
                if (player.atk >= enemy.def)
                    enemy.hp -= player.atk - enemy.def;
                else
                    enemy.hp--;
            }
            else if(atkType.chosen == 1)
            {
                skillType.startSelection = true;
                if(skillType.startSelection == false)
                {
                    // do selection stuff here
                }
            }
            else if(atkType.chosen == 2)
            {
                // send message and change scene
                Debug.Log("Here");
                SceneManager.LoadScene(0);
            }
        }
        if(!playerTurn && enemy != null && enemy.hp <= 0)
        {
            // message that you defeated enemy.
            player.exp += enemy.level * 8;
            SceneManager.LoadScene(0);
        }
        else if(player != null && player.gold < 0)
        {
            // game over
        }
	}
}
