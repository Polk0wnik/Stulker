using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image imageSlot;
    private Color currentColor;
    private ItemSlot itemInSlot;
    private void Awake()
    {
        imageSlot = GetComponent<Image>();
        itemInSlot = transform.GetChild(0).GetComponent<ItemSlot>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        currentColor = imageSlot.color;
        imageSlot.color = Color.gray; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imageSlot.color = currentColor;
    }
    public void SetItem(ItemData newItem)
    {
        itemInSlot.SetItem(newItem);
    }
    public void ResetItem()
    {
        itemInSlot.ResetItem();
    }
}
