using System;
using System.Collections;
using System.Collections.Generic;
using MM;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuButtonsController : Singleton<MenuButtonsController> {
   public Button playButton;
   public ModeButton arcadeButton, distanceButton, timeButton;

   private void Start() {
      arcadeButton.Select();
   }

   public void DeselectAll() {
      arcadeButton.Deselect();
      distanceButton.Deselect();
      timeButton.Deselect();
   }
   
   
}
public enum ButtonType {
   Arcade, Time,Distance
}