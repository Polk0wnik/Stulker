using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "Item")]
public class ItemData : ScriptableObject
{
    public float healAmmount;
    public float damageAmmout;
    public float strengthAmmout = 100;
    public float weightAmmount;
    public string nameItem;
    public int ammount = 1;
    public Sprite icon;
    public bool isEquippingItem;
    public bool isUsingItem;
    public ItemEqiupTypes itemType;
    public UseItemTypes useItemType;
}
public enum ItemEqiupTypes
{
    None,
    Helmet,
        ArmorVest,
        Backpack,
        Weapon,
        Perchatki,
        Boots
}
public enum UseItemTypes
{
    None,
    Medic,
    Food,
    Bullet
    
}