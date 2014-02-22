using UnityEngine;
using System.Collections;

public class Lander : MonoBehaviour {

	void Start() {
	}
	
	void Update() {
		GameState state = GameState.Instance;
		if (state.Grounded) {
			return;
		}
		if (Input.GetMouseButtonDown(0)) {
			if (rigidbody2D.gravityScale != 0.0f) {
				if (state.Fuel > 0) {
					rigidbody2D.AddForce(new Vector2(0, 80));
					state.Fuel--;
				}
			} else {
				rigidbody2D.gravityScale = 1.0f;
			}
		}
		state.Speed = (int)Mathf.Round(rigidbody2D.velocity.y / -2);
	}

	void KnockOver() {
		rigidbody2D.AddTorque(-2);
	}
}
