using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	private const int LEVELS = 30;

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
		float top = (position + 5) * (Screen.height / 8.0f);
		float left = Screen.width * 0.15f;
		float width = Screen.width - left * 2.0f;
		float height = Screen.height / 10.0f;
		return new Rect(left, top, width, height);
	}

	public bool LandIsCreated = false;

	private int level;
	private int maxLevel;
	public int Level {
		get {
			return level;
		}
		private set {
			level = value;
			if (level > maxLevel) {
				maxLevel = level;
				Debug.Log("New max level: " + maxLevel);
				PlayerPrefs.SetInt("maxLevel", maxLevel);
				PlayerPrefs.Save();
			}
			Fuel = (int)Mathf.Round(100.0f - 80.0f * (value / LEVELS));
		}
	}
	public int Speed;
	public bool Crashed;
	public bool Landed;
	public int Fuel;

	private Timer landMoveTimer = new Timer();

	public float GroundSpeed {
		get {
			if (landMoveTimer.Finished) {
				return -2.0f + (Level / (float)LEVELS) * -5.0f;
			} else {
				return 0;
			}
		}
	}

	private float FlatProbability {
		get {
			float flatProbability = 1.0f - (Level / (float)LEVELS);
			if (flatProbability > 0.4f) {
				flatProbability = 0.4f;
			}
			return flatProbability;
		}
	}

	public int RandomSlope {
		get {
			int delta;
			int randInt = Random.Range(0, 101);
			if ((randInt / 100.0f) < FlatProbability) {
				delta = 0;
			} else {
				if (Random.Range(0, 2) == 0) {
					delta = -1;
				} else {
					delta = 1;
				}
			}
			return delta;
		}
	}

	public bool Grounded {
		get {
			return Crashed || Landed;
		}
	}

	void Start() {
		Level = PlayerPrefs.GetInt("maxLevel");
		landMoveTimer.Start(this, 1);
	}

	void Update() {
	}

	public void GiveUp() {
		Application.LoadLevel("SplashScene");
	}

	public void Quit() {
		Level = Level + 1;
		GiveUp();
	}
	
	public void RestartLevel() {
		Application.LoadLevel("LandingScene");
		Speed = 0;
		Crashed = false;
		Landed = false;
		Fuel = 100;
	}

	public void StartLevel(int level) {
		Level = level;
		RestartLevel();
	}

	public void LoadNextLevel() {
		Level++;
		RestartLevel();
	}
}
