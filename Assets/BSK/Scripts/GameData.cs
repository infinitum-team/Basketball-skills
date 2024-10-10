using System.Collections;
using System.Collections.Generic;
using MM;
using UnityEngine;
using UnityEngine.Events;

public class GameData : Singleton<GameData> {
  private int _totalScore;
  public UnityEvent onTotalScoreChanged;

    float amountToUnlockLevel=10000;
   
   
  public int TotalScore {
    get {
      _totalScore = PlayerPrefs.GetInt(Constants.totalCoinsAmount);
      return _totalScore;
    }
    set {
      _totalScore = PlayerPrefs.GetInt(Constants.totalCoinsAmount)+value;
      PlayerPrefs.SetInt(Constants.totalCoinsAmount, _totalScore);
      onTotalScoreChanged.Invoke();
    }
  }
  public void SetLevelUnlockProgress(int score) {
    //amountToUnlockLevel=amountToUnlockLevel*(PlayerPrefs.GetInt(Constants.maxLevelIndex,0)+1);
    float multiplicator = PlayerPrefs.GetInt(Constants.maxLevelIndex, 0) + 1;
    float devider = amountToUnlockLevel * multiplicator;
    float result=score/devider;
    Debug.Log("Amount To Unlock level: "+devider);
    Debug.Log("Score: "+score+" gayofa ---- "+devider+"  result: "+result);
    if (result>=GetLevelUnlockProgress()) {
      PlayerPrefs.SetFloat(Constants.levelUnclokProgress,result);
    } else {
      PlayerPrefs.SetFloat(Constants.levelUnclokProgress,result+GetLevelUnlockProgress());
    }
   
  }
 

  public float  GetLevelUnlockProgress() {
    return PlayerPrefs.GetFloat(Constants.levelUnclokProgress, 0);
  }

  public bool IsTutorialPassed() {
    return PlayerPrefs.GetInt(Constants.tutorialState, 0) != 0;
  }

  public void PassTheTutorial() {
    PlayerPrefs.SetInt(Constants.tutorialState, 1);
  }
  void Start() {
    //Test
   // TotalScore = 5000;
  // PlayerPrefs.SetInt(Constants.totalCoinsAmount,20000);
  }
}