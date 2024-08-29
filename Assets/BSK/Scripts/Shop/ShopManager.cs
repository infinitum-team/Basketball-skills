﻿using System;
using System.Collections;
using System.Collections.Generic;
using MM;
using UnityEngine;
using UnityEngine.UI;







public class ShopManager : Singleton<ShopManager>
{

    public GameObject ItemsUIPanel;
    public GameObject shopItemPrefab;
    public List<ShopItemData> itemsHolder;
    public List<ShopItemInfo> shopItems;

    private void Start() {
        SyncShopItems();
    }

    private void SyncShopItems() {
        for (int i = 1; i < itemsHolder.Count; i++) {
            ShopItemInfo item = Instantiate(shopItemPrefab, ItemsUIPanel.transform).GetComponent<ShopItemInfo  >();
            ShopItemData currentItemData = itemsHolder[i];
            shopItems.Add(item);
            item.Sync(currentItemData.UI_Icon,currentItemData.price,GetShopItemStatus(currentItemData.index),currentItemData.index,currentItemData.prefab);
        }
    }

    public void DeselectAll() {
        for (int i = 0; i < shopItems.Count; i++) {
            shopItems[i].Deselect();
        }
    }
    public static ShopItemStatus GetShopItemStatus(int index)
    {
        int prefValue=PlayerPrefs.GetInt(Constants.ItemUnlockStatusPlayerPrefsTag + index.ToString(), 3);
        return (ShopItemStatus)prefValue;
    }
    public static void SetShopItemStatus(int index, ShopItemStatus status)
    {
        PlayerPrefs.SetInt(Constants.ItemUnlockStatusPlayerPrefsTag +index.ToString(), (int)status);
    }


}


