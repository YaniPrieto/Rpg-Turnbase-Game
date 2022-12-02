using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UnitScriptableObject playerData;
    // Start is called before the first frame update
    void Start()
    {
        BattleUI.instance.PlayerSetup(playerData);
    }
    public bool TakeDamage(int dmg)
    {
        playerData.currentHp -= dmg;

        if(playerData.currentHp <= 0)
            return true;
        else
            return false;

    }
}
