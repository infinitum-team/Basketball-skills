using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallItem", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
[Serializable]
public class ShopItemData : ScriptableObject
{
  public string Name;
  public int index;
  [Space(10)]
  public GameObject prefab;
  //public bool DisplayPreview = false;
  public Sprite UI_Icon;

  [Space(10)]
  public bool unlocked;
  public int price;
}
