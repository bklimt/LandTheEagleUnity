using UnityEngine;
using System.Collections;

public class Ambiance : MonoBehaviour {

	void Start() {
		StartCoroutine(PlayMusic());
	}
	
	void Update() {
	}

	private IEnumerator PlayMusic() {
		while (true) {
			yield return new WaitForSeconds(30);
			gameObject.audio.Play();
		}
	}
}
