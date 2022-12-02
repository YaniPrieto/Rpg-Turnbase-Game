using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    [Header("Units")]
    [SerializeField]GameObject playerUnit;
    [SerializeField]GameObject enemyUnit;
    
    [Header("Unit Station")]
    [SerializeField]Transform playerStation;
    [SerializeField]Transform enemyStation;

    Player playerModel;
    Enemy enemyModel;

    [Header("Battle State")]
    public BattleState state;

    [Header("Dialog")]
    [SerializeField]Text dialogText;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerObject = Instantiate(playerUnit, playerStation);
        playerModel = playerObject.GetComponent<Player>();

        GameObject enemyObject = Instantiate(enemyUnit, enemyStation);
        enemyModel = enemyObject.GetComponent<Enemy>();
        dialogText.text ="A wild " + enemyModel.enemyData.UnitName + " appeared.";

        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    void PlayerTurn() 
    {
        dialogText.text = "Choose an action: ";
    }
    public IEnumerator  OnAttackButton()
    {
        bool enemyDead = enemyModel.TakeDamage(playerModel.playerData.damage);
        BattleUI.instance.SetEnemyHP(enemyModel.enemyData.currentHp);
        dialogText.text = "The attack is successful!";
        yield return new WaitForSeconds(2f);

        if(enemyDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else 
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    public void AttackButton(){
        StartCoroutine(OnAttackButton());
    }

    IEnumerator EnemyTurn()
    {
        dialogText.text = enemyModel.enemyData.UnitName + " attacks!";
        bool playerDead = playerModel.TakeDamage(enemyModel.enemyData.damage);
        BattleUI.instance.SetPlayerHP(playerModel.playerData.currentHp);
        yield return new WaitForSeconds(1f);
        if(playerDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }else
        {
            state = BattleState.PLAYERTURN;
        }

    }

    void EndBattle() 
    {
        if(state == BattleState.WON)
        {
            dialogText.text = "You won the battle!";
        } else if (state == BattleState.LOST)
        {
            dialogText.text = "You were defeated!";
        }
    }


}
