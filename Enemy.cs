using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnitScriptableObject enemyData;
    // Start is called before the first frame update
    void Start()
    {
        BattleUI.instance.EnemySetup(enemyData);
    }
    public bool TakeDamage(int dmg)
    {
        enemyData.currentHp -= dmg;

        if(enemyData.currentHp <= 0)
            return true;
        else
            return false;

    }
}
