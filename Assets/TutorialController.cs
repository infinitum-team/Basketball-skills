using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {
  public GameObject tutorialParent;
  public GameObject handAnim;
  public GameObject releaseObject;
  private bool tutorialisActive = false;
  public GameObject tutorialBall;
  public GameObject ballTxt;

  private void Update() {
    if (tutorialisActive) {
      if (Input.GetMouseButton(0)) {
        handAnim.gameObject.SetActive(false);
        releaseObject.gameObject.SetActive(true);
      }
      if (Input.GetMouseButtonUp(0)) {
        tutorialisActive = false;
        tutorialBall.gameObject.SetActive(true);
        ballTxt.gameObject.SetActive(true);
        releaseObject.gameObject.SetActive(false);
        Invoke(nameof(PassTheTutorial),15f);
      }
    }
  }

  private void PassTheTutorial() {
    GameData.Instance.PassTheTutorial();
    tutorialBall.gameObject.SetActive(false);
    tutorialParent.gameObject.SetActive(false);
  }
  private void Start() {
    if (!GameData.Instance.IsTutorialPassed()) {
       tutorialParent.SetActive(true);
       tutorialisActive = true;
    }
  }
}
