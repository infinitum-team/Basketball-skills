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
  private void Start() {
    selectButton.onClick.AddListener(OnSelectButtonClick);
    int maxLevelIndex = PlayerPrefs.GetInt(Constants.maxLevelIndex, 1);
    int selectedLevelIndex = PlayerPrefs.GetInt(Constants.currentLevelIndex,0);
    for (int i = 0; i < maxLevelIndex; i++) {
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
}
