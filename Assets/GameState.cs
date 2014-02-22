using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	private static GameState instance;

	public static GameState Instance {
		get {
			if (instance == null) {
				instance = new GameObject("GameState").AddComponent<GameState>();
				DontDestroyOnLoad(instance);
			}
			return instance;
		}
	}

	public static Rect GetGUIButtonRect(int position) {
		float top = (Screen.height / 2.0f) + position * (Screen.height / 6.0f);
		float left = Screen.width * 0.15f;
		float width = Screen.width - left * 2.0f;
		float height = Screen.height / 7.0f;
		return new Rect(left, top, width, height);
	}

	public bool LandIsCreated = false;

	public int Level { get; private set; }
	public int Speed;
	public bool Crashed;
	public bool Landed;
	public int Fuel;

	private Timer landMoveTimer = new Timer();

	public float GroundSpeed {
		get {
			if (landMoveTimer.Finished) {
				return -5.0f;
			} else {
				return 0;
			}
		}
	}

	public bool Grounded {
		get {
			return Crashed || Landed;
		}
	}

	void Start() {
		Level = 0;
		Fuel = 100000;
		landMoveTimer.Start(this, 2);
	}

	void Update() {
	}

	public void Quit() {
		Application.LoadLevel("SplashScene");
	}

	public void RestartLevel() {
		Application.LoadLevel("LandingScene");
		Speed = 0;
		Crashed = false;
		Landed = false;
		Fuel = 100;
	}
	
	public void LoadNextLevel() {
		Level++;
		RestartLevel();
	}
}
