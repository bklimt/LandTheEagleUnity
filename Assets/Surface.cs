using UnityEngine;
using System.Collections;

public class Surface : MonoBehaviour {

	public GameObject surfaceTopTopPrefab;
	public GameObject surfaceTopBottomPrefab;
	public GameObject surfaceBottomTopPrefab;
	public GameObject surfaceFillerPrefab;
	public bool createRight = true;
	public bool rightIsLower = false;
	public bool isFlat = false;

	private bool haveCreatedRight = false;
	private int rows = 7;
	private float maxY = -1.0f;
	private float minY = -3.0f;

	void Start() {
		MaybeCreateChildren();
	}

	private void MaybeCreateChildren() {
		if (createRight && !haveCreatedRight && transform.position.x < 5) {
			haveCreatedRight = true;
			
			int slope = Random.Range(-1, 2);
			if (slope < 0 && transform.position.y < minY) {
				slope = 0;
			}
			if (slope > 0 && transform.position.y > maxY) {
				slope = 0;
			}
			
			float scaleX = transform.localScale.x;
			float scaleY = transform.localScale.y;
			
			// Change this if the tile size changes.
			float boxSizeX = 1.28f;
			float boxSizeY = 1.28f;
			
			float newX = transform.position.x + scaleX * boxSizeX;
			float newY = transform.position.y;
			float newZ = transform.position.z;
			
			if (rightIsLower) {
				newY -= (scaleY * boxSizeY);
			}
			if (slope > 0) {
				newY += (scaleY * boxSizeY);
			}
			
			Vector3 newPosition = new Vector3(newX, newY, newZ);
			if (slope < 0) {
				Instantiate(surfaceTopBottomPrefab, newPosition, Quaternion.identity);
			} else if (slope > 0) {
				Instantiate(surfaceBottomTopPrefab, newPosition, Quaternion.identity);
			} else {
				Instantiate(surfaceTopTopPrefab, newPosition, Quaternion.identity);
			}
			
			for (int i = 1; i < rows; i++) {
				newY -= (scaleY * boxSizeY);
				Vector3 childPosition = new Vector3(newX, newY, newZ);
				Instantiate(surfaceFillerPrefab, childPosition, Quaternion.identity);
			}
		}
	}

	void Update() {
		GameState state = GameState.Instance;
		if (!state.Grounded) {
			transform.Translate(state.GroundSpeed * Time.deltaTime, 0, 0);
		}

		MaybeCreateChildren();

		if (transform.position.x < -6) {
			Destroy(this.gameObject);
		}
	}
}
