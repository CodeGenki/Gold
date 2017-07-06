using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBattle : MonoBehaviour {

    public static bool playerTurn;
    public GameControl player;
    public EnemyGenerator enemy;

    public SelectionManager atkType;
    public SelectionManager skillType;

    // Use this for initialization
    void Start () {
        atkType = new SelectionManager();
        skillType = new SelectionManager();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerTurn && enemy.hp > 0)
        {
            atkType.startSelection = true;
            if(atkType.startSelection == false)
            {
                if(atkType.selectedItem == 0)       // Regular attack
                {
                    // atk animation
                    if (player.atk >= enemy.def)
                        enemy.hp -= player.atk - enemy.def;
                    else
                        enemy.hp--;
                }
                else if(atkType.selectedItem == 1)
                {
                    skillType.startSelection = true;
                    if(skillType.startSelection == false)
                    {
                        // do selection stuff here
                    }
                }
                else if(atkType.selectedItem == 2)
                {
                    // send message and change scene
                    SceneManager.LoadScene(0);
                }
            }
        }
        if(enemy.hp <= 0)
        {
            // message that you defeated enemy.
            player.exp += enemy.level * 5;
            SceneManager.LoadScene(0);
        }
        else if(player.gold < 0)
        {
            // game over
        }
	}
}
