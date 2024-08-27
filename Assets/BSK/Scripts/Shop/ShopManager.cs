using System;
using System.Collections;
using System.Collections.Generic;
using MM;
using UnityEngine;
using UnityEngine.UI;







public class ShopManager : Singleton<ShopManager>
{

    public GameObject ItemsUIPanel;
    public List<ShopItemData> itemsHolder;
 
    

    public static bool GetShopItemUnlockStatus(int index)
    {
        return PlayerPrefs.GetInt(Constants.ItemUnlockStatusPlayerPrefsTag + index.ToString(), 0) == 1;
    }
    public static void SetShopItemUnlockStatus(int index, bool unlocked)
    {
        PlayerPrefs.SetInt(Constants.ItemUnlockStatusPlayerPrefsTag +index.ToString(), unlocked ? 1 : 0);
    }


}


