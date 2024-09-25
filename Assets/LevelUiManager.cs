using System;
using System.Collections;
using System.Collections.Generic;
using MM;
using UnityEngine;
using UnityEngine.UI;

public class LevelUiManager : Singleton<LevelUiManager>
{
  public List<LevelUiItem> levelUiItems;
  public Button selectButton;
  public List<GameObject> ObjectToActivateDeactivateOnOpen;
  private void Start() {
    selectButton.onClick.AddListener(OnSelectButtonClick);
    int maxLevelIndex = PlayerPrefs.GetInt(Constants.maxLevelIndex, 0);
    int selectedLevelIndex = PlayerPrefs.GetInt(Constants.currentLevelIndex,0);
    for (int i = 0; i <= maxLevelIndex; i++) {
      levelUiItems[i].Unlock();
    }
    levelUiItems[selectedLevelIndex].Select();
  }

  public void DeselectAll() {
    foreach (var levelUi in levelUiItems) {
      if (!levelUi.locked) {
        levelUi.selectedVisual.gameObject.SetActive(false);
      }
    }
  }

  public void OnSelectButtonClick() {
    LevelManager.Instance.SpawnLevel();
  }
  public void OnLevelSelectOPen() {
    foreach (var obj in ObjectToActivateDeactivateOnOpen) {
      obj.gameObject.SetActive(false);
    }
  }

  public void OnLevelSelectClose() {
    foreach (var obj in ObjectToActivateDeactivateOnOpen) {
      obj.gameObject.SetActive(true);
    }
  }
}
