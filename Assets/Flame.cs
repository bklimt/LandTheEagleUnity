using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {
	private float maxScale = 0.15f;
	private float minScale = 0.08f;
	private bool flaring = false;

	void Start() {
	}
	
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			flaring = true;
		}
		if (flaring) {
			if (transform.localScale.x < maxScale) {
				// Flaring completely should take .2s to change by .07, so 0.35 per second.
				transform.localScale = new Vector2(
					transform.localScale.x + (Time.deltaTime * 0.35f),
					transform.localScale.y + (Time.deltaTime * 0.35f));
			} else {
				flaring = false;
			}
		} else {
			if (transform.localScale.x > minScale) {
				transform.localScale = new Vector2(
					transform.localScale.x - (Time.deltaTime * 0.35f),
					transform.localScale.y - (Time.deltaTime * 0.35f));
			}
		}
	}
}
