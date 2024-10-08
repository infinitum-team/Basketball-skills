using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour {
   public GameObject congratsMode;
   public List<GameObject> objectsToDeactivateOnCongrats;
   public Image fillerImage;
   public Text fillerText;
   public Button PressToChooseLevelBtn;

   private void Start() { 
      PressToChooseLevelBtn.onClick.AddListener((() => 
         GameController.data.loadMenu()));
   }

   private void OnEnable() {
      if (GameData.Instance.GetLevelUnlockProgress()>1) {
         Debug.Log("Seems new level has Unlocked");
         congratsMode.gameObject.SetActive(true);
         foreach (var item in objectsToDeactivateOnCongrats) {
            item.SetActive(false);
         }
         fillerImage.transform.parent.gameObject.SetActive(false);
      } else {
         float roundedValue = (float)Math.Round(GameData.Instance.GetLevelUnlockProgress(), 1);
         fillerText.text = "YOU ARE " + roundedValue * 100 + "% " +
                           "CLOSER TO THE NEW LEVEL";
         fillerImage.fillAmount = GameData.Instance.GetLevelUnlockProgress();
      }
   }
}
