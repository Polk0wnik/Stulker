using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    private CharacterHp hpChar;
    private void Awake()
    {
        hpChar = FindObjectOfType<CharacterHp>();
    }
    public bool HealHP(ItemData item)
    {
        if(item.useItemType == UseItemTypes.Medic)
        {
            hpChar.HealHp(item.healAmmount);
            return true;
        }
        else
        {
            return false;
        }
    }
}
