using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemInfo : MonoBehaviour
{
    public Image Icon;
    public Image selectImage;
    public Image lockedImage;

    [Space(5)]
    public Button button;
    public Text priceText;
    public GameObject associatedItemPrefab;

    [HideInInspector] public int index;
    [HideInInspector] public int price;

    public ShopItemStatus itemStatus;
    public bool unlocked=false;
    public void Refresh_UI()
    {
        priceText.text = price.ToString() + "$"; //MoneyCount.ConvertMoney(price);
    }

    private void Start() {
        
        button.onClick.AddListener(OnShopItemClick);
    }


    public void Sync(Sprite itemIcon, int itemPrice, ShopItemStatus shopItemStatus, int itemIndex, GameObject itemPrefab) {
        Icon.sprite = itemIcon;
        price = itemPrice;
        priceText.text=itemPrice.ToString();
        itemStatus = shopItemStatus;
        Debug.Log(itemStatus);
        index = itemIndex;
        associatedItemPrefab = itemPrefab;
        switch (shopItemStatus) {
            case ShopItemStatus.locked:
                break;
            case ShopItemStatus.bought:
                Unlock();
                break;
            case ShopItemStatus.selected:
                Select();
                break;
          
        }
    }

    public void OnShopItemClick() {
        Select();
    }
    private void Unlock()
    {
        //unlocked = true;
        lockedImage.gameObject.SetActive(true); 
        SetData();
    }

    private void Select() {
        if (!(itemStatus == ShopItemStatus.selected)) {
            ShopManager.Instance.DeselectAll();
            selectImage.gameObject.SetActive(true);
            itemStatus = ShopItemStatus.selected;
        } else {
            Deselect();
        }

    }

    public void Deselect() {
        if (unlocked) {
            itemStatus = ShopItemStatus.bought;
        } else {
            itemStatus = ShopItemStatus.locked;
        }
        selectImage.gameObject.SetActive(false);
    }

    public void GetData()
    {
      
    }

    public void SetData()
    {
   
    }

}
[System.Serializable]
public enum ShopItemStatus: int
{
    bought=1, selected=2, locked=3
}