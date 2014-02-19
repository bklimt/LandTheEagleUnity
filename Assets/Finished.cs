using UnityEngine;
using System.Collections;

public class Finished : MonoBehaviour {
	public GameObject lander;

	void Start() {
	}
	
	void Update() {
	}

	void OnGUI() {
		if (!lander.GetComponent<Lander>().IsGrounded()) {
			return;
		}
		GUI.Label(new Rect(100, 100, 100, 40), "You're done!");
		if (GUI.Button(new Rect(100, 180, 100, 40), "Restart")) {
			Application.LoadLevel("LandingScene");
		}
	}
}
