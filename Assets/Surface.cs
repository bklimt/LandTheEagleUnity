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
			// Debug.Log("Need to create a child land strip to the right. " +
			//           "(x = " + transform.position.x + "," +
			//           " scaleX = " + transform.localScale.x + "," +
			//           " boxSizeX = " + 1.28f + ")");

			haveCreatedRight = true;
			
			int slope = Random.Range(-1, 2);
			// Debug.Log("Initial random slope is " + slope);
			if (slope < 0 && transform.position.y < minY) {
				// Debug.Log("Too low. Flattening.");
				slope = 0;
			}
			if (slope > 0 && transform.position.y > maxY) {
				// Debug.Log("Too high. Flattening.");
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
			// Debug.Log("Making new top tile at " + newPosition);

			GameObject newTile = null;
			if (slope < 0) {
				// Debug.Log("Making downslope.");
				newTile = Instantiate(surfaceTopBottomPrefab, newPosition, Quaternion.identity) as GameObject;
			} else if (slope > 0) {
				// Debug.Log("Making upslope.");
				newTile = Instantiate(surfaceBottomTopPrefab, newPosition, Quaternion.identity) as GameObject;
			} else {
				// Debug.Log("Making flat surface.");
				newTile = Instantiate(surfaceTopTopPrefab, newPosition, Quaternion.identity) as GameObject;
			}
			if (newTile == null) {
				Debug.LogError("The new tile was null!");
			}
			
			for (int i = 1; i < rows; i++) {
				newY -= (scaleY * boxSizeY);
				Vector3 childPosition = new Vector3(newX, newY, newZ);
				// Debug.Log("Making filler at " + childPosition + ".");
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
