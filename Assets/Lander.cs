using UnityEngine;
using System.Collections;

public class Lander : MonoBehaviour {

	public GameObject body;

	void Start() {
	}
	
	void Update() {
		if (this.IsGrounded()) {
			return;
		}
		if (Input.GetMouseButtonDown(0)) {
			if (rigidbody2D.gravityScale != 0.0f) {
				rigidbody2D.AddForce(new Vector2(0, 80));
			} else {
				rigidbody2D.gravityScale = 1.0f;
			}
		}
	}

	public bool IsGrounded() {
		return body.GetComponent<LanderBody>().IsGrounded();
	}
}
