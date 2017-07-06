using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour {

    public enum attackOption
    {
        attack,
        skill,
        run
    }

    public attackOption option;
    public Text atkText;
    public Text skillText;
    public Text runText;

	// Use this for initialization
	void Start () {
		option = attackOption.attack;
        atkText.color = Color.yellow;
        skillText.color = Color.black;
        runText.color = Color.black;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (option < attackOption.run)
            {
                option++;
                if(option == attackOption.attack)
                {
                    atkText.color = Color.yellow;
                    skillText.color = Color.black;
                    runText.color = Color.black;
                }
                else if(option == attackOption.skill)
                {
                    atkText.color = Color.black;
                    skillText.color = Color.yellow;
                    runText.color = Color.black;
                }
                else if(option == attackOption.run)
                {
                    atkText.color = Color.black;
                    skillText.color = Color.black;
                    runText.color = Color.yellow;
                }
            }
            else if (option == attackOption.run)
            {
                option = attackOption.attack;
                atkText.color = Color.yellow;
                skillText.color = Color.black;
                runText.color = Color.black;
            }            
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            DoBattleAction();
        }
    }
    void DoBattleAction()
    {
        if(option == attackOption.attack)
        {
            //PlayerAttack.Attack();
            Debug.Log("Attacking");
        }
    }
}
