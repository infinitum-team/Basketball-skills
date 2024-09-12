using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoins : MonoBehaviour {
  public Text totalCoinsText;

  private void Start() {
    GameData.Instance.onTotalScoreChanged.AddListener(SyncTotalCoins);
    SyncTotalCoins();
  }

  public void SyncTotalCoins() {
    totalCoinsText.text = PlayerPrefs.GetInt(Constants.totalCoinsAmount, 0).ToString();
  }
}
