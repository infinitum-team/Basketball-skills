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


    [HideInInspector] public bool unlocked = false;
    [HideInInspector] public int index;
    [HideInInspector] public int price;

    public shopItemStatus itemStatus;
    public void Refresh_UI()
    {
        priceText.text = price.ToString() + "$"; //MoneyCount.ConvertMoney(price);
    }

   

    public void Unlock()
    {
        unlocked = true;
        SetData();
    }

    public void getData()
    {
        if (!unlocked)
        {
            unlocked = ShopManager.GetShopItemUnlockStatus(index);
        }
        else
        {
            ShopManager.SetShopItemUnlockStatus(index, unlocked);
        }


       // GameManager.GetInstance().shopManager.shopItems[tabType].TabData[index].unlocked = unlocked;
    }

    public void SetData()
    {
      //  GameManager.GetInstance().shopManager.shopItems[tabType].TabData[index].unlocked = unlocked;
        ShopManager.SetShopItemUnlockStatus(index, unlocked);
    }

}
[System.Serializable]
public enum shopItemStatus
{
    bought, selected, locked
}