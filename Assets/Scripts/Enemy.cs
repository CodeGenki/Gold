using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private GameControl player;
    private EnemyGenerator enemy;

    public static bool enemyTurn;
    public static bool isDead;

	// Use this for initialization
	void Start () {
        enemyTurn = false;
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyTurn && !isDead)
        {
            // Do attack animation
            if (enemy.atk - player.def > 0)
                player.gold -= (enemy.atk - player.def);
            else
                player.gold -= 1;
            enemyTurn = false;
            PlayerBattle.playerTurn = true;
        }
        if(enemy.hp <= 0)
        {
            // Die animation
            isDead = true;
        }
	}
}
