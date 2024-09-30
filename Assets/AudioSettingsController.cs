using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsController : MonoBehaviour {
  public Slider musicSlider;
  public Slider vfxSlider;

  private AudioSource targetSource;

  private void Awake() {
    targetSource = FindObjectOfType<AudioSource>();
  }

  private void Start() {
    musicSlider.onValueChanged.AddListener(delegate {MusicSliderChanged();});
    vfxSlider.onValueChanged.AddListener(delegate {VfxSliderChanged();});
    Sync();
  }
private void Sync() {
  musicSlider.value = PlayerPrefs.GetFloat(Constants.soundlevel,1);
  vfxSlider.value = PlayerPrefs.GetFloat(Constants.vfxLevel, 1);
  targetSource.volume = musicSlider.value;
}
  private void MusicSliderChanged() {
    Debug.Log(musicSlider.value);
   PlayerPrefs.SetFloat(Constants.soundlevel,musicSlider.value);
   targetSource.volume = musicSlider.value;
  }

  private void VfxSliderChanged() {
    PlayerPrefs.SetFloat(Constants.vfxLevel,vfxSlider.value);
    targetSource.volume = vfxSlider.value;
  }
}
