using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public static BattleUI instance;
    [Header("Player UI")]
    [SerializeField]Text playerNameText;
    [SerializeField]Text playerLevelText;
    [SerializeField]Slider playerHealth;
    [SerializeField]SpriteRenderer playerSprite;

    [Header("Enemy UI")]
    [SerializeField]Text enemyNameText;
    [SerializeField]Text enemyLevelText;
    [SerializeField]Slider enemyHealth;
    [SerializeField]SpriteRenderer enemySprite;

    [Header("User Interface")]
    [SerializeField]Text dialogText;

    public void Start()
    {
        CreateInstance();
    }
    private void CreateInstance(){
    if(instance == null){
        instance = this;
        }
    }
    public void PlayerSetup(UnitScriptableObject player)
    {
        playerNameText.text = player.UnitName;
        playerLevelText.text = "Lvl "+player.UnitLevel;
        playerHealth.maxValue = player.maxHp;
        playerHealth.value = player.currentHp;
        playerSprite.sprite = player.artSprite;
    }
    public void EnemySetup(UnitScriptableObject enemy)
    {
        enemyNameText.text = enemy.UnitName;
        enemyLevelText.text = "Lvl "+ enemy.UnitLevel;
        enemyHealth.maxValue = enemy.maxHp;
        enemyHealth.value = enemy.currentHp;
        enemySprite.sprite = enemy.artSprite;
    }
    public void SetPlayerHP(int hp){
        playerHealth.value = hp;
    }
    public void SetEnemyHP(int hp){
        enemyHealth.value = hp;
    }    
}
