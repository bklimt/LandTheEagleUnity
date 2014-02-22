using UnityEngine;
using System.Collections;

public class Ambiance : MonoBehaviour {
	public float seconds = 30;

	void Start() {
		StartCoroutine(PlayMusic());
	}
	
	void Update() {
	}

	private IEnumerator PlayMusic() {
		while (true) {
			yield return new WaitForSeconds(seconds);
			gameObject.audio.Play();
		}
	}
}
