using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	private static GameState instance;

	public static GameState Instance {
		get {
			if (instance == null) {
				instance = new GameObject("GameState").AddComponent<GameState>();
				DontDestroyOnLoad(instance);

				instance.Level = 0;
			}
			return instance;
		}
	}

	public int Level { get; private set; }
	public int Speed;
	public bool Crashed;
	public bool Landed;
	public int Fuel;

	public bool Grounded {
		get {
			return Crashed || Landed;
		}
	}

	void Start() {
		Fuel = 100000;
	}

	void Update() {
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
	
	void OnGUI() {
		GUI.Label(new Rect(100, 50, 300, 80), "Level: " + Level);
		GUI.Label(new Rect(100, 70, 300, 80), "Speed: " + Speed);
		GUI.Label(new Rect(100, 90, 300, 80), "Fuel: " + Fuel);
	}
}
