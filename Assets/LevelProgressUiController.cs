using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUiController : MonoBehaviour {
 public List<Sprite> levelIcons;
 public Image currentLvlImage, nextLvlImage;
 public Image fillerImage;
 private void Start() {
  //Debug.Log("Start happened");
  Sync();
 }

 private void OnEnable() {
  if (PlayerPrefs.GetInt(Constants.maxLevelIndex, 0) + 1 >= levelIcons.Count) {
   this.gameObject.SetActive(false);
  }
 }

 public void Sync() {
  int maxUnlockedLevelId = PlayerPrefs.GetInt(Constants.maxLevelIndex,0);
//  Debug.Log(maxUnlockedLevelId+" Max unlocked LevelID");
  if (maxUnlockedLevelId+1>=levelIcons.Count) {
   //Debug.Log("Levels maxed");
    this.gameObject.SetActive(false);
   return;
  } else {
   
   fillerImage.fillAmount=GameData.Instance.GetLevelUnlockProgress();
   //Debug.Log("fileer "+fillerImage.fillAmount);
   if (fillerImage.fillAmount>=1) {
    fillerImage.fillAmount = 0;
    PlayerPrefs.SetFloat(Constants.levelUnclokProgress,0);
    LevelManager.Instance.UnlockNewLevel(maxUnlockedLevelId+1);
   }
   currentLvlImage.sprite = levelIcons[PlayerPrefs.GetInt(Constants.maxLevelIndex,0)];
   nextLvlImage.sprite = levelIcons[PlayerPrefs.GetInt(Constants.maxLevelIndex,0) + 1];
  }
  
 }
}
