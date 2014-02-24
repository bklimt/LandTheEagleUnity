using UnityEngine;
using System.Collections;

public class ThemeSwitcher : MonoBehaviour {
	public bool ivyMode;

	void Start() {
	}
	
	void Update() {
		GameState state = GameState.Instance;
		GetComponent<SpriteRenderer>().enabled = (state.IvyMode == ivyMode);
	}
}
