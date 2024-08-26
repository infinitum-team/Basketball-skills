using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public enum shopItemStatus
{
    bought, selected, locked
}



public class ShopManager : MonoBehaviour
{

    public GameObject ItemUIPrefab;
 
 
    

    public static bool GetShopItemUnlockStatus(int index)
    {
        return PlayerPrefs.GetInt(Constants.ItemUnlockStatusPlayerPrefsTag + index.ToString(), 0) == 1;
    }
    public static void SetShopItemUnlockStatus(int index, bool unlocked)
    {
        PlayerPrefs.SetInt(Constants.ItemUnlockStatusPlayerPrefsTag +index.ToString(), unlocked ? 1 : 0);
    }


}
[System.Serializable]
public class ShopItemData
{
    public string Name;

    [Space(10)]
    public GameObject prefab;
    //public bool DisplayPreview = false;
    public Sprite UI_Icon;

    [Space(10)]
    public bool unlocked;
    public int price;
}


