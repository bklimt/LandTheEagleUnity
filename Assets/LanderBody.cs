using UnityEngine;
using System.Collections;

public class LanderBody : MonoBehaviour {
	private bool crashed = false;
	private bool landed = false;

	void Start() {
	}
	
	void Update() {
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (!crashed) {
			crashed = true;
		}
	}

	public bool IsGrounded() {
		return crashed || landed;
	}	
}
