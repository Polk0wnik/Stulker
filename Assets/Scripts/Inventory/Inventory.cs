using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]private List<Slot> slots = new List<Slot>();
    [SerializeField]private List<ItemSlot> itemSlot = new List<ItemSlot>();
    public event Func<List<ItemData>> onGetItems;
    private void Awake()
    {
        slots.AddRange(FindObjectsOfType<Slot>(false));
        itemSlot.AddRange(FindObjectsOfType<ItemSlot>(false));
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void SetNewItemByInventore(int index, ItemData newItem)
    {
        List<ItemData> items = onGetItems?.Invoke();
        if (index < items.Count && items[index] != null)
        {
            slots[index].SetItem(newItem);
        }
    }    
    public void ResetByInventory(int index)
    {
        List<ItemData> items = onGetItems?.Invoke();
        if (index < items.Count)
        { 
            slots[index].ResetItem();
        }
    }
    public void UpdateInventorySlot()
    {
        List<ItemData> items = onGetItems?.Invoke();
        for (int i = 0; i < slots.Count; i++) 
        {
            if (itemSlot[i].itemData != null)
            {
                slots[i].ResetItem();
            }
            if (i < items.Count && items[i] != null)
            {
                slots[i].SetItem(items[i]);
            }
        }
    }
}
