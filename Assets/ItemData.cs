using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "itemType",
    menuName = "Items/ItemData",
    order = 1)]
public class ItemData : ScriptableObject
{

    public int coins;
    public float health;


}
