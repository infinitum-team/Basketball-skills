using System.Collections;
using System.Collections.Generic;
using MM;
using UnityEngine;

public class LevelManager : Singleton<LevelManager> {
   public List<GameObject> levels;
   private GameObject currentLevel;
     void Start() {
      //UnlockNewLevel(4);
     SpawnLevel();
   }

   public void UnlockNewLevel(int index) {
      PlayerPrefs.SetInt(Constants.maxLevelIndex,index);
      LevelUiManager.Instance.levelUiItems[index].Unlock();
   }

   public void SpawnLevel() {
      if (currentLevel!=null) {
         Destroy(currentLevel);
      }
      currentLevel = Instantiate(levels[PlayerPrefs.GetInt(Constants.currentLevelIndex)]);
   }

  
}
