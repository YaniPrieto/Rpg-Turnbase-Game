using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class UnitScriptableObject : ScriptableObject
{

    public string UnitName;
    public int UnitLevel;
    public Sprite artSprite;
    public int damage;
    public int maxHp;
    public int currentHp;
}
