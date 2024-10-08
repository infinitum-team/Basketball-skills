using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {
  public GameObject tutorialParent;
  public GameObject handAnim;
  public GameObject releaseObject;
  private bool tutorialisActive = false;

  private void Update() {
    if (tutorialisActive) {
      if (Input.GetMouseButton(0)) {
        handAnim.gameObject.SetActive(false);
        releaseObject.gameObject.SetActive(true);
      }
      if (Input.GetMouseButtonUp(0)) {
        tutorialisActive = false;
        GameData.Instance.PassTheTutorial();
        tutorialParent.gameObject.SetActive(false);
      }
    }
  }

  private void Start() {
    if (!GameData.Instance.IsTutorialPassed()) {
       tutorialParent.SetActive(true);
       tutorialisActive = true;
    }
  }
}
