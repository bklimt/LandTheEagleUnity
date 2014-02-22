using UnityEngine;
using System.Collections;

public class LanderBody : MonoBehaviour {

	void Start() {
	}
	
	void Update() {
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		GameState state = GameState.Instance;
		if (state.Grounded) {
			return;
		}
		if (state.Speed >= 3) {
			state.Crashed = true;
			return;
		}
		state.Landed = true;
	}
}
