using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUiItem : MonoBehaviour {
   public GameObject selectedVisual;
   public GameObject lockedVisual;
   public Button button;
   public bool locked;
   public int index;
   private void Start() {
      button.onClick.AddListener(Select);
   }

   public void Select() {
      if (!locked) {
         LevelUiManager.Instance.DeselectAll();
         selectedVisual.gameObject.SetActive(true);
         PlayerPrefs.SetInt(Constants.currentLevelIndex,index);
      }
   }

   public void Unlock() {
      lockedVisual.gameObject.SetActive(false);
      locked = false;
   }
}
