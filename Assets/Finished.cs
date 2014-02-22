using UnityEngine;
using System.Collections;

public class Finished : MonoBehaviour {
	void Start() {
	}
	
	void Update() {
	}

	void OnGUI() {
		GameState state = GameState.Instance;
		if (!state.Grounded) {
			return;
		}
		if (state.Crashed) {
			GUI.Label(new Rect(100, 100, 100, 40), "You crashed!");
			if (GUI.Button(new Rect(100, 180, 100, 40), "Retry")) {
				state.RestartLevel();
			}
		} else {
			GUI.Label(new Rect(100, 100, 100, 40), "You're done!");
			if (GUI.Button(new Rect(100, 180, 100, 40), "Next Level")) {
				state.LoadNextLevel();
			}
		}
	}
}
