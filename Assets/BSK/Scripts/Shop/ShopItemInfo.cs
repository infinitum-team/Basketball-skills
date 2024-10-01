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
    public GameObject boughtVisual;
    [Space(5)]
    public Button button;
    public Text priceText;
    public GameObject associatedItemPrefab;
    public GameObject selectWhenLockedVisual;
     public int index;
     public int price;

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
       
        index = itemIndex;
//        Debug.Log(itemStatus+"  in Sync +"+ index);
        associatedItemPrefab = itemPrefab;
        switch (shopItemStatus) {
            case ShopItemStatus.locked:
                break;
            case ShopItemStatus.bought:
                Unlock();
                break;
            case ShopItemStatus.selectedAndBought:
                ShopManager.Instance.DeselectAll();
                selectImage.gameObject.SetActive(true);
                boughtVisual.gameObject.SetActive(false);
                
                lockedImage.gameObject.SetActive(false);
                ShopManager.Instance.selectedItem = this;
                unlocked = true;
                itemStatus = ShopItemStatus.selectedAndBought;
                break;
          
        }
    }

    public void OnShopItemClick() {
        Select();
    }
    private void Unlock()
    {
        //unlocked = true;
        lockedImage.gameObject.SetActive(false);
        boughtVisual.gameObject.SetActive(true);
        itemStatus = ShopItemStatus.bought;
        unlocked = true;
        SetData();
    }

    private void Select() {
        if (!(itemStatus == ShopItemStatus.selected)) {
            ShopManager.Instance.DeselectAll();
            selectImage.gameObject.SetActive(true);
            boughtVisual.gameObject.SetActive(false);
            itemStatus = ShopItemStatus.selected;
            ShopManager.Instance.selectedItem = this;
            if (!unlocked) {
                ShopManager.Instance.buyButton.gameObject.SetActive(true);
                selectWhenLockedVisual.gameObject.SetActive(true);
                selectImage.gameObject.SetActive(false);
                boughtVisual.gameObject.SetActive(false);
            } else {
                
                Debug.Log("sdfsdfsdfsdfsdfds"+ itemStatus);
                itemStatus = ShopItemStatus.selectedAndBought;
                ShopManager.Instance.SetShopItemStatus(index,itemStatus);
            }
            
        } else {
            Deselect();
        }

    }

    public void Deselect() {
        if (unlocked) {
            itemStatus = ShopItemStatus.bought;
            boughtVisual.gameObject.SetActive(true);
            selectImage.gameObject.SetActive(false);
        } else {
            itemStatus = ShopItemStatus.locked;
            selectWhenLockedVisual.gameObject.SetActive(false);
        }
        selectImage.gameObject.SetActive(false);
        ShopManager.Instance.buyButton.gameObject.SetActive(false);
        ShopManager.Instance.SetShopItemStatus(index,itemStatus);
    }

    public void GetData()
    {
      
    }

    public void SetData()
    {
      
    }

    public void TryToPurchaseItem() {
        Debug.Log("TryToPurchaseItem");
        ShopManager.Instance.confirmationPanel.transform.parent.gameObject.SetActive(false);
        if (price<=GameData.Instance.TotalScore) {
            GameData.Instance.TotalScore = -price;
            itemStatus = ShopItemStatus.selectedAndBought;
            unlocked = true;
            lockedImage.gameObject.SetActive(false);
            selectWhenLockedVisual.gameObject.SetActive(false);
            boughtVisual.gameObject.SetActive(true);
            selectImage.gameObject.SetActive(true);
            ShopManager.Instance.SetShopItemStatus(index, itemStatus);
        } else {
            Debug.Log("No money no funny");
            Debug.Log(GameData.Instance.TotalScore);
        }
    }

}
[System.Serializable]
public enum ShopItemStatus: int
{
    bought=1, selected=2,selectedAndBought=3, locked=4
}