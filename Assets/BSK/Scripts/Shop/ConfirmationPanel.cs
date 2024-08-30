using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationPanel : MonoBehaviour {
    public Button yesButton;
    public Button noButton;

    private void Start() {
        noButton.onClick.AddListener(OnNoButtonClick);
    }

   

    public void OnNoButtonClick() {
        gameObject.SetActive(false);
    }
}
