
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private TMP_Text quantityTxt;
    [SerializeField]
    private Image borderImage;

    public event Action<UIInventoryItem> OnItemClicked,OnRigthMouseBtnClikck;

    private bool empty = true;

    void Awake()
    {
        ResetData();
        Deselect();
    }

    // Update is called once per frame
    void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        empty = true;
    }


    void SetData(Sprite sprite, int quantity) 
    { 
        this.itemImage.gameObject.SetActive (true);
        this.itemImage.sprite = sprite;
        this.quantityTxt.text = quantity + "";
        empty = false;
    }
    void Deselect()
    {
        borderImage .enabled = false;
    }

    void Select()
    {
        borderImage.enabled = true;
    }

    private void OnMouseOver()
    {
        Select();
    }

    private void OnMouseExit()
    {
        Deselect();
    }



}
