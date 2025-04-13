using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour , IBeginDragHandler , IDragHandler , IEndDragHandler, IPointerClickHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform regTransItem;
    private Canvas canvas;
    private Transform slotTrans;
    public ItemData itemData;
    private Image imageItem;
    private TextMeshProUGUI textItem;
    private UseItem useItem;
    private void Awake()
    {
        regTransItem = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = regTransItem.GetComponentInParent<Canvas>();
        imageItem = GetComponent<Image>();
        textItem = GetComponentInChildren<TextMeshProUGUI>();
        useItem = FindObjectOfType<UseItem>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.5f;
        slotTrans = transform.parent;
        regTransItem.SetParent(canvas.transform);
        regTransItem.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        regTransItem.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        regTransItem.SetParent(slotTrans);
    }
    public void SetItem(ItemData newItem)
    {
        itemData = newItem;
        imageItem.sprite = itemData.icon;
        textItem.text = itemData.nameItem;
        imageItem.enabled = true;
    }
    public void ResetItem()
    {
        itemData = null;
        imageItem.sprite = null;
        textItem.text = "";
        imageItem.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            bool isHeal = useItem.HealHP(itemData);
            Debug.Log(isHeal);
            if(isHeal)
            {
                ResetItem();
            }
        }
    }
}
