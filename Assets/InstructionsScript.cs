using UnityEngine;
using System.Collections;

public class InstructionsScript : MonoBehaviour {

	void Start() {
	}
	
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Destroy(this.gameObject);
		}
	}

	void OnGUI() {
		GUI.Label(new Rect(100, 100, 300, 80), "Instructions!");
	}
}
