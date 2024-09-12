using System.Collections;
using System.Collections.Generic;
using MM;
using UnityEngine;
using UnityEngine.Events;

public class GameData : Singleton<GameData> {
  private int _totalScore;
  public UnityEvent onTotalScoreChanged;

  public int TotalScore {
    get { return _totalScore; }
    set {
      _totalScore = value;
      PlayerPrefs.SetInt(Constants.totalCoinsAmount, _totalScore);
      onTotalScoreChanged.Invoke();
    }
  }

 

  void Start() {
    //Test
    TotalScore = 5000;
  }
}