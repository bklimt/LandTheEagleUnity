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
		Surface surface = collision.collider.gameObject.GetComponent<Surface>();
		if (!surface.isFlat || state.Speed >= 3) {
			state.Crashed = true;
			SendMessageUpwards("KnockOver");
			return;
		}
		state.Landed = true;
	}
}
