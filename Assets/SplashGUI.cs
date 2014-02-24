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
		if (state.IsHighDpi()) {
			GUI.skin.label.fontSize = 72;
			GUI.skin.button.fontSize = 48;
		}

		GUI.Label(new Rect(0, 0, Screen.width, Screen.height / 2), "Land the Eagle");
		
		Rect button0Rect = GameState.GetGUIButtonRect(-2);
		if (GUI.Button(button0Rect, "Skip Last")) {
			state.StartLevel(49);
		}

		Rect button1Rect = GameState.GetGUIButtonRect(-1);
		if (GUI.Button(button1Rect, (state.Level == 0 ? "Start" : ("Level " + (state.Level + 1))))) {
			state.RestartLevel();
		}

		if (state.HasWon) {
			Rect button2Rect = GameState.GetGUIButtonRect(0);
			if (GUI.Button(button2Rect, "Switch Theme")) {
				state.IvyMode = !state.IvyMode;
			}
		}

		Rect button3Rect = GameState.GetGUIButtonRect(1);
		if (GUI.Button(button3Rect, "Quit")) {
			Application.Quit();
		}
	}

}
