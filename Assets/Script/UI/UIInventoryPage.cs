using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem itemPrefab;
    [SerializeField]
    private RectTransform contentPanel;

    List<UIInventoryItem> inventoryItems = new List<UIInventoryItem>();

    public void InitilizeInventoryUI (int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab,Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            inventoryItems.Add(uiItem);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide() 
    { 
        gameObject.SetActive(false);
    }
   
}
