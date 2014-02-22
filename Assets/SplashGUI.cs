using UnityEngine;
using System.Collections;

public class SplashGUI : MonoBehaviour {

	public GUISkin defaultSkin;

	void Start() {
	}
	
	void Update() {
	}

	void OnGUI() {
		GameState state = GameState.Instance;

		GUI.skin = defaultSkin;
		GUI.Label(new Rect(0, 0, Screen.width, Screen.height / 2), "Land the Eagle");
		Rect button1Rect = GameState.GetGUIButtonRect(0);
		if (GUI.Button(button1Rect, "Start")) {
			state.RestartLevel();
		}
	}

}
