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
		state.Crashed = false;
		state.Landed = false;

		GUI.skin = defaultSkin;
		if (Screen.dpi > 200) {
			GUI.skin.label.fontSize = 72;
			GUI.skin.button.fontSize = 48;
		}

		GUI.Label(new Rect(0, 0, Screen.width, Screen.height / 2), "Land the Eagle");
		
		/*
		Rect button0Rect = GameState.GetGUIButtonRect(-2);
		if (GUI.Button(button0Rect, "Skip Last")) {
			state.StartLevel(29);
		}
		*/
		
		Rect button1Rect = GameState.GetGUIButtonRect(0);
		if (GUI.Button(button1Rect, (state.Level == 0 ? "Start" : ("Level " + (state.Level + 1))))) {
			state.RestartLevel();
		}

		Rect button2Rect = GameState.GetGUIButtonRect(1);
		if (GUI.Button(button2Rect, "Quit")) {
			Application.Quit();
		}
	}

}
