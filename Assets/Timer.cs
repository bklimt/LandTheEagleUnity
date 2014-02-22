using UnityEngine;
using System.Collections;

public class Timer {
	public bool Started = false;
	public bool Finished = false;

	private class CancellationToken {
		public bool Cancelled = false;
	}
	private CancellationToken currentToken = new CancellationToken();

	public Timer() {
	}

	public void Start(MonoBehaviour owner, float seconds) {
		if (Started) {
			return;
		}

		Started = true;
		Finished = false;
		owner.StartCoroutine(Wait(seconds, currentToken));
	}

	public void Reset() {
		Cancel();
		Started = false;
		Finished = false;
	}

	public void Cancel() {
		if (Started && !Finished) {
			currentToken.Cancelled = true;
		}
		currentToken = new CancellationToken();
	}

	private IEnumerator Wait(float seconds, CancellationToken token) {
		yield return new WaitForSeconds(seconds);
		if (!token.Cancelled) {
			Finished = true;
		}
	}
}

