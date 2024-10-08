using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeButton : MonoBehaviour {
  public Button modeButton;
  public ButtonType buttonType;
  public Color blackColor;
  public delegate void CurrentFunction();
  private void Start() {
    modeButton = GetComponent<Button>();
    modeButton.onClick.AddListener(Select);
  }

  public void Select() {
    MenuButtonsController.Instance.playButton.onClick.RemoveAllListeners();
    MenuButtonsController.Instance.DeselectAll();
    modeButton.image.color = Color.white;
   // transform.GetComponent<RectTransform>().localScale = new Vector3(1.3f, 1.3f, 1.3f);
    switch (buttonType) {
            case ButtonType.Arcade:
              MenuButtonsController.Instance.playButton.onClick.AddListener(FunctionArcade);
              break;
            case ButtonType.Distance:
              MenuButtonsController.Instance.playButton.onClick.AddListener(FunctionDistance);
              break;
            case ButtonType.Time:
              MenuButtonsController.Instance.playButton.onClick.AddListener(FunctionTime);
              break;
    }
  }

  public void Deselect() {
   // transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
    modeButton.image.color = blackColor;
  }
  
  
  public static void FunctionArcade()
  {
    MenuController.Instance.StartArcadeMode();
  }

  public static void FunctionTime()
  {
    MenuController.Instance.StartTimeAttackMode();
  }

  public static void FunctionDistance()
  {
    MenuController.Instance.StartDistanceMode();
  }
}
