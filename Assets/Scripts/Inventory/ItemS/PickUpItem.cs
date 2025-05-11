using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private AnimCharacter anim;
    private CharacterMove charact;
    private InventoryController invent;
    private Transform transItem;
    private Transform transChar;
    public ItemData item;

    private void Awake()
    {
        transItem = GetComponent<Transform>();
        charact = FindObjectOfType<CharacterMove>();
        transChar = charact.GetComponent<Transform>();
        invent = FindObjectOfType<InventoryController>();
        anim = FindObjectOfType<AnimCharacter>();
    }
    //1 - скрипт должен висеть на игровом объекте по которому хотим кликнуть. 
    //2 - На игр об должен быть колайдер
    public void Interact()
    {
        bool isAdd = invent.AddItemForInventory(item);
        Debug.Log("Pick Up Item - " + item.nameItem + " " + isAdd);
        if (isAdd)
        {
            anim.PickUpItemAnim();
            gameObject.SetActive(false);
        }
    }
    public bool PickWeapon()
    {
        if(item.itemType == ItemEqiupTypes.Weapon)
        {
            return true;

        }
        else
        {
            return false;
        }
    }
}
