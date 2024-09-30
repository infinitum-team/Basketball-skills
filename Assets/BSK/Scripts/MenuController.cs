using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {
	
	public GameObject panelSettings;
	public Toggle soundToggle;
	public Toggle inverseAimToggle;

	public List<GameObject> ObjectsToDeactivateActivateOnSettings;
	void Start(){
		soundToggle.isOn = PlayerPrefs.GetFloat(Constants.soundlevel, 1) >= 1 ? true : false;
		AudioListener.volume = PlayerPrefs.GetInt(Constants.soundlevel, 1);
		inverseAimToggle.isOn = PlayerPrefs.GetInt("inverseAim", 0) == 1 ? true : false;
	}
	
	void Update(){
		if (Input.GetKey(KeyCode.R))
            Application.LoadLevel(Application.loadedLevel);
	}
	
	public void StartArcadeMode(){
		Application.LoadLevel("gameArcade");
	}
	
	public void StartTimeAttackMode(){
		Application.LoadLevel("gameTimeAttack");
	}
	public void StartDistanceMode(){
		Application.LoadLevel("gameDistance");
	}
	
	public void switchSettings(){
		foreach (var gObject in ObjectsToDeactivateActivateOnSettings) {
			gObject.gameObject.SetActive(panelSettings.activeInHierarchy);
		}
		panelSettings.SetActive(!panelSettings.activeInHierarchy);
	}
	
	public void switchSound(){
		PlayerPrefs.GetFloat(Constants.soundlevel, PlayerPrefs.GetFloat(Constants.soundlevel, 1) >= 1 ? 0 : 1);
		AudioListener.volume = PlayerPrefs.GetFloat(Constants.soundlevel, 1);
	}
	
	public void switchShadow(){
		PlayerPrefs.SetInt("inverseAim", PlayerPrefs.GetInt("inverseAim", 0) == 1 ? 0 : 1);
	}
}
