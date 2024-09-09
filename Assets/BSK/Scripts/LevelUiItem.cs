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
   private void Start() {
      button.onClick.AddListener(Select);
   }

   private void Select() {
      if (!locked) {
         selectedVisual.gameObject.SetActive(true);
      }
   }
}
