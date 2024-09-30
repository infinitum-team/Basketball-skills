using System.Collections;
using System.Collections.Generic;
using MM;
using UnityEngine;
using UnityEngine.Events;

public class GameData : Singleton<GameData> {
  private int _totalScore;
  public UnityEvent onTotalScoreChanged;

   static float amountToUnlockLevel=100;
  public int TotalScore {
    get { return _totalScore; }
    set {
      _totalScore = value;
      PlayerPrefs.SetInt(Constants.totalCoinsAmount, _totalScore);
      onTotalScoreChanged.Invoke();
    }
  }
  public void SetLevelUnlockProgress(int score) {
    float result=(score / amountToUnlockLevel);
    Debug.Log("Amount To Unlock level: "+amountToUnlockLevel);
    Debug.Log("Score: "+score+" Result ---- "+result);
    if (result>=GetLevelUnlockProgress()) {
      PlayerPrefs.SetFloat(Constants.levelUnclokProgress,result);
    } else {
      PlayerPrefs.SetFloat(Constants.levelUnclokProgress,result+GetLevelUnlockProgress());
    }
   
  }
 

  public float  GetLevelUnlockProgress() {
    return PlayerPrefs.GetFloat(Constants.levelUnclokProgress, 0);
  }
 

  void Start() {
    //Test
    //TotalScore = 5000;
  }
}