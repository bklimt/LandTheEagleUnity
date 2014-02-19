using UnityEngine;
using System.Collections;

public class Surface : MonoBehaviour {

	public GameObject lander;
	public GameObject surfaceTopTopPrefab;
	public GameObject surfaceTopBottomPrefab;
	public GameObject surfaceBottomTopPrefab;
	public GameObject surfaceFillerPrefab;
	public bool createRight = true;
	public bool rightIsLower = false;

	private bool haveCreatedRight = false;
	private int rows = 6;
	private float speed = -0.05f;
	private float maxY = -1.0f;
	private float minY = -3.0f;

	void Start() {
	}
	
	void Update() {
		if (!lander.GetComponent<Lander>().IsGrounded()) {
			transform.Translate(speed, 0, 0);
		}

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
				var obj = (GameObject)Instantiate(surfaceTopBottomPrefab, newPosition, Quaternion.identity);
				obj.GetComponent<Surface>().lander = lander;
			} else if (slope > 0) {
				var obj = (GameObject)Instantiate(surfaceBottomTopPrefab, newPosition, Quaternion.identity);
				obj.GetComponent<Surface>().lander = lander;
			} else {
				var obj = (GameObject)Instantiate(surfaceTopTopPrefab, newPosition, Quaternion.identity);
				obj.GetComponent<Surface>().lander = lander;
			}

			for (int i = 1; i < rows; i++) {
				newY -= (scaleY * boxSizeY);
				Vector3 childPosition = new Vector3(newX, newY, newZ);
				var obj = (GameObject)Instantiate(surfaceFillerPrefab, childPosition, Quaternion.identity);
				obj.GetComponent<Surface>().lander = lander;
			}
		}

		if (transform.position.x < -5) {
			Destroy(this.gameObject);
		}
	}
}
