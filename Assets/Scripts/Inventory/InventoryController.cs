using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public readonly List<ItemData> items = new List<ItemData>();
    public int inventorySpace = 16;
    private Inventory inventoryUI;
    private void Awake()
    {
        inventoryUI = FindObjectOfType<Inventory>();
    }
    private void OnEnable()
    {
        inventoryUI.onGetItems += GetCurrentItems;
    }
    private void OnDisable()
    {
        inventoryUI.onGetItems -= GetCurrentItems;
    }
    private void Start()
    {
        for (int index = 0; index < inventorySpace; index++)
        {
            items.Add(null);
        }
    }
    public bool AddItemForInventory(ItemData newItem)
    {
        for (int index = 0; index < inventorySpace; index++)
        {
            if (items[index] == null)
            {
                items[index] = newItem;
                inventoryUI.SetNewItemByInventore(index, newItem);
                return true;
            }
        }
        return false;
    }
    
    public void Remove(ItemData item)
    {
        for(int index = 0; index < inventorySpace; index++)
        {
            if (items[index] == item)
            {
                items[index] = null;
                inventoryUI.ResetByInventory(index);
                return;
            }
        }
    }
    public List<ItemData> GetCurrentItems()
    {
        return items;
    }
}
